import { Component, inject } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth-service';

@Component({
  selector: 'app-register-page',
  imports: [ReactiveFormsModule],
  templateUrl: './register-page.html',
  styleUrl: './register-page.scss',
})
export class RegisterPage {
  private readonly _fb = inject(FormBuilder);
  private readonly _authService = inject(AuthService);
  private readonly _router = inject(Router);

  userName = new FormControl('', [Validators.required]);
  passWord = new FormControl('', [Validators.required]);
  email = new FormControl('', [Validators.required]);

  registerForm = this._fb.group({
    userName: this.userName,
    email: this.email,
    password: this.passWord,
  });

  registerError = '';

  onSubmit() {
    if (this.registerForm.valid) {
      this._authService
        .register({
          username: this.registerForm.value.userName!,
          email: this.registerForm.value.email!,
          password: this.registerForm.value.password!,
        })
        .then(() => {
          // redirigé
          this._router.navigate(['/authentication/login']);
        })
        .catch((err) => {
          console.error(err);
          this.registerError = err.message;
        });
    }
  }
}
