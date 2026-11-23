import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { AuthService } from '../../../services/auth-service';

@Component({
  imports: [RouterLink, ReactiveFormsModule],
  selector: 'app-login',
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {

  private fb = inject(FormBuilder);
  private authService = inject(AuthService);

  loginForm = this.fb.nonNullable.group(
    {
      email: ['', [
        Validators.required,
        Validators.email,
      ]],
      password: ['', [
        Validators.required,
      ]],
    }
  )
  
  onLogin(): void {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }
  
    this.authService.login(this.loginForm.getRawValue()).subscribe({
      next: (response) => {
        const { success, message, data } = response;
  
        if (!success) {
          console.error(message);
          return;
        }
  
        // Handle successful login
        console.log('Login successful:', data);
      },
  
      error: (err) => {
        console.error(
          'Login failed:',
          err.error?.message ?? 'Something went wrong'
        );
      }
    });
  }
}

