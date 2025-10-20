import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  constructor(private http: HttpClient, private router: Router, private authService: AuthService) { }

  public async onSubmit() {
    if (!this.email || !this.password) {
      alert('Please enter both email and password');
      return;
    }

    if (this.authService.isLoggedIn()) {
      alert('You are already logged in');
      return;
    }

    this.authService.login(this.email, this.password).subscribe({
      next: () => this.router.navigate(['/home']),
      error: err => console.error('Login failed', err)
    });
  }

}
