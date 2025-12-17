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
import { RaceTraitList } from '@core/models/raceTrait/race-trait-list.model';

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
    this.loadLanguageFilter('');
  }

  removeLanguage(index: number) {
    console.log(index);

    this.languagesFormArray.removeAt(index);
  }
  onClickLanguageInput(id: number) {
    console.log(id);

    const languageValue: string = this.languageList.find((l) => l.id === id)?.name ?? '';
    this.loadLanguageFilter(languageValue);
    console.log(languageValue);
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
        if (this.languageList.find((l) => l.name == filter) === undefined) {
          this.invalidLanguage = true;
        }
      }
      this.cdr.markForCheck();
    });
  }
  // #endregion

  // #region RaceTraits
  raceTraitList: RaceTraitList[] = [];
  raceTraitsFormArray = this._fb.array([
    this._fb.group({
      raceTrait: ['', Validators.required],
    }),
  ]);

  raceTraitForm = this._fb.group({
    raceTraits: this.raceTraitsFormArray,
  });

  addRaceTrait() {
    this.raceTraitsFormArray.push(
      this._fb.group({
        raceTrait: ['', [Validators.required]],
      }),
    );
    this.loadRaceTraitFilter('');
  }

  removeRaceTrait(index: number) {
    this.raceTraitsFormArray.removeAt(index);
  }
  onClickRacetraitInput(id: number) {
    console.log(id);

    const languageValue: string = this.languageList.find((l) => l.id === id)?.name ?? '';
    this.loadLanguageFilter(languageValue);
    console.log(languageValue);
  }
  onSubmitRacetrait() {}

  invalidRaceTrait: boolean = true;
  loadRaceTraitFilter(filter: string) {
    this._raceTraitService.getSomeByName(filter).then((data) => {
      if (data.length == 0) {
        this.invalidRaceTrait = true;
      } else {
        this.raceTraitList = data;
        this.invalidRaceTrait = false;
        if (this.raceTraitList.find((rt) => rt.name == filter) === undefined) {
          this.invalidRaceTrait = true;
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

    this._raceTraitService.getRaceTraits().then((data) => {
      this.raceTraitList = data;
      this.cdr.markForCheck();
    });
  }
}
