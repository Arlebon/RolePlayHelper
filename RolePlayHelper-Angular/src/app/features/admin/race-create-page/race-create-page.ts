import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { LanguageList } from '@core/models/language/language-list.model';
import { LanguageService } from 'src/app/services/language-service';
import { raceTraitService } from 'src/app/services/race-trait-service';

@Component({
  selector: 'app-race-create-page',
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './race-create-page.html',
  styleUrl: './race-create-page.scss',
})
export class RaceCreatePage implements OnInit {
  private readonly _fb = inject(FormBuilder);
  private readonly _raceTraitService = inject(raceTraitService);
  private readonly _languageService = inject(LanguageService);
  private readonly _router = inject(Router);

  constructor(private cdr: ChangeDetectorRef) {}
  raceTraitOptions: string[] = ['str', 'dex', 'cha', 'int', 'wis', 'con'];

  language = new FormControl('', [Validators.required]);
  languages = this._fb.array([
    this._fb.group({
      language: this.language,
    }),
  ]);

  raceLanguageForm = this._fb.group({
    languages: this.languages,
  });

  addLangue() {
    this.languages.push(
      this._fb.group({
        language: ['', [Validators.required]],
      }),
    );
  }
  languageList: LanguageList[] = [];
  ngOnInit(): void {
    this._languageService.getLanguages().then((data) => {
      this.languageList = data;
      console.log(this.languageList);
    });
  }

  removeLanguage(index: number) {
    console.log(index);

    this.languages.removeAt(index);
  }
}
