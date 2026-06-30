import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  standalone: true,
  template: `
    <div class="container">
      <h1>Welcome to MrFamilyTree Admin</h1>
      <p>This is the administration panel for managing your family tree.</p>
    </div>
  `
})
export class HomeComponent {}
