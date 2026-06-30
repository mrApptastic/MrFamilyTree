import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  template: `
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <a class="navbar-brand" routerLink="/">MrFamilyTree</a>
      <button class="navbar-toggler" type="button" (click)="isCollapsed = !isCollapsed">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" [class.show]="!isCollapsed">
        <ul class="navbar-nav me-auto">
          <li class="nav-item">
            <a class="nav-link" routerLink="/" routerLinkActive="active" [routerLinkActiveOptions]="{exact: true}">Home</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" routerLink="/control" routerLinkActive="active">Control Room</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" routerLink="/score-board" routerLinkActive="active">Score Board</a>
          </li>
        </ul>
      </div>
    </nav>
  `,
  styles: [`
    .navbar { margin-bottom: 1rem; }
  `]
})
export class NavMenuComponent {
  isCollapsed = true;
}
