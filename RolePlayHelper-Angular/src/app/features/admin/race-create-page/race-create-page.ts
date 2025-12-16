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
import { InputAutocompleteList } from '@components/common/input-autocomplete-list/input-autocomplete-list';

@Component({
  selector: 'app-race-create-page',
  imports: [ReactiveFormsModule, FormsModule, InputAutocompleteList],
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

  // #region Languages
  languageList: LanguageList[] = [];
  languagesFormArray = this._fb.array([
    this._fb.group({
      language: ['', Validators.required],
    }),
  ]);

  raceLanguageForm = this._fb.group({
    languages: this.languagesFormArray,
  });

  addLanguage() {
    this.languagesFormArray.push(
      this._fb.group({
        language: ['', [Validators.required]],
      }),
    );
  }

  removeLanguage(index: number) {
    console.log(index);

    this.languagesFormArray.removeAt(index);
  }

  onSubmitLanguage() {}

  invalidLanguage: boolean = true;
  loadLanguageFilter(filter: string) {
    this._languageService.getSomeByName(filter).then((data) => {
      if (data.length == 0) {
        this.invalidLanguage = true;
      } else {
        this.languageList = data;
        this.invalidLanguage = false;
        if (this.languageList.find((r) => r.name == filter) === undefined) {
          this.invalidLanguage = true;
        }
      }
      this.cdr.markForCheck();
    });
  }
  // #endregion

  ngOnInit(): void {
    this._languageService.getLanguages().then((data) => {
      this.languageList = data;
      this.cdr.markForCheck();
    });
  }
}
