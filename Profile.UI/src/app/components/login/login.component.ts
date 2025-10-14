import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private http: HttpClient, private router: Router) {

  }

  public onSubmit() {
    const loginData = { email: this.email, password: this.password };
    this.http.post<any>("myApi", loginData).subscribe({
      next: (response) => {
        console.log('Login successful!', response);
        this.router.navigate(['/home']);
      },
      error: (error) => {
        console.error('There was an error during the login process!', error);
        alert('An error occurred. Please try again later.');
      }
    });
  }
}
