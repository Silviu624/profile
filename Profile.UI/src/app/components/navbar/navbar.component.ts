import { Component, OnChanges, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/authService';

@Component({
  selector: 'app-navbar',
  standalone: false,
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  constructor(private _authService: AuthService, private router: Router) { }

  public isLoggedInFunction(): boolean {
    return this._authService.isLoggedIn();
  }

  public logout() {
    localStorage.removeItem("access_token");
  }
}
