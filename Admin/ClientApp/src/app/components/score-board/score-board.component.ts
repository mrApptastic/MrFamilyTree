import { Component, inject } from '@angular/core';
import { DatePipe } from '@angular/common';
import { ChatService } from '../../services/chat.service';

@Component({
  selector: 'app-score-board',
  standalone: true,
  imports: [DatePipe],
  template: `
    <div class="container">
      <h2>Score Board</h2>
      <p>Connection status: {{ chatService.connectionEstablished() ? 'Connected' : 'Disconnected' }}</p>
      <div class="messages">
        @for (msg of chatService.messages(); track msg.date) {
          <div class="message-item">
            <strong>{{ msg.type }}:</strong> {{ msg.content }}
            <small class="text-muted">{{ msg.date | date:'short' }}</small>
          </div>
        }
      </div>
    </div>
  `
})
export class ScoreBoardComponent {
  chatService = inject(ChatService);
}
