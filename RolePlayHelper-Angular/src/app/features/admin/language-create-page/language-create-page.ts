import { Component, inject } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  Validators,
  ɵInternalFormsSharedModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ApiError } from '@core/models/authentication-models';
import { LanguageService } from 'src/app/services/language-service';

@Component({
  selector: 'app-language-create-page',
  imports: [ɵInternalFormsSharedModule, ReactiveFormsModule],
  templateUrl: './language-create-page.html',
  styleUrl: './language-create-page.scss',
})
export class LanguageCreatePage {
  private readonly _fb = inject(FormBuilder);
  private readonly _languageService = inject(LanguageService);
  private readonly _router = inject(Router);

  language = new FormControl('', [Validators.required]);

  languageForm = this._fb.group({
    language: this.language,
  });

  errorMessage = '';
  async onSubmit() {
    if (this.languageForm.valid) {
      try {
        await this._languageService.PostLanguage({
          name: this.languageForm.value.language!,
        });
        this._router.navigate(['/language']);
      } catch (err) {
        console.log(err);
        this.errorMessage = (err as ApiError).message;
      }
    }
  }
}
