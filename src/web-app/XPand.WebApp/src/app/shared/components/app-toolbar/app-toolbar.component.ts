import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-toolbar',
  templateUrl: './app-toolbar.component.html',
  styleUrl: './app-toolbar.component.css'
})
export class AppToolbarComponent {

  constructor(public auth:AuthService) {}

  onLogin() {
    this.auth.loginWithRedirect();
  }

  onLogout() {
    this.auth.logout();
  }
}
