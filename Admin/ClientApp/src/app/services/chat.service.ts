import { Injectable, signal } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { Message } from '../models/message';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private hubConnection!: HubConnection;
  public messages = signal<Message[]>([]);
  public connectionEstablished = signal(false);

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  sendMessage(message: Message): void {
    this.hubConnection.invoke('NewMessage', message);
  }

  private createConnection(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('/MessageHub')
      .withAutomaticReconnect()
      .configureLogging(LogLevel.Information)
      .build();
  }

  private startConnection(): void {
    this.hubConnection
      .start()
      .then(() => {
        this.connectionEstablished.set(true);
        console.log('Hub connection started');
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...', err);
        setTimeout(() => this.startConnection(), 5000);
      });
  }

  private registerOnServerEvents(): void {
    this.hubConnection.on('MessageReceived', (data: Message) => {
      this.messages.update(msgs => [...msgs, data]);
    });
  }
}
