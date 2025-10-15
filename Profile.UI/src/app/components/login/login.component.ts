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
    this.http.get<any>("https://localhost:7000/api/home").subscribe({
      next: (response) => {
        console.log('Login successful!', response);
        this.router.navigate(['/home']);
      },
      error: (error) => {
        console.error('There was an error during the login process!', error);
        alert('An error occurred. Please try again later.');
      }
    });


    // const loginData = { email: this.email, password: this.password };
    // localStorage.setItem("access_token", "dummy_token");
    // this.router.navigate(['/home']);
  }

}
