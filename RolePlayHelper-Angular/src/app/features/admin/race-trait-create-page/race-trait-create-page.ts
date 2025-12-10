import { Component, inject } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ApiError } from '@core/models/authentication-models';
import { RaceTraitCreateModel } from '@core/models/raceTrait/race-trait-create-model';
import { RaceService } from 'src/app/services/race-service';
import { raceTraitService } from 'src/app/services/race-trait-service';

@Component({
  selector: 'app-race-trait-create-page',
  imports: [ReactiveFormsModule],
  templateUrl: './race-trait-create-page.html',
  styleUrl: './race-trait-create-page.scss',
})
export class RaceTraitCreatePage {
  private readonly _fb = inject(FormBuilder);
  private readonly _raceTraitService = inject(raceTraitService);
  private readonly _router = inject(Router);

  traitName = new FormControl('', [Validators.required]);
  description = new FormControl('', [Validators.required]);

  raceTraitForm = this._fb.group({
    traitName: this.traitName,
    description: this.description,
  });

  errorMessage = '';
  onSubmit() {
    const raceTrait: RaceTraitCreateModel = {
      name: this.raceTraitForm.value.traitName!,
      description: this.raceTraitForm.value.description!,
    };
    try {
      this._raceTraitService.postRaceTrait(raceTrait);
      this._router.navigate(['/race-trait']);
    } catch (err) {
      this.errorMessage = (err as ApiError).message;
      console.log(err);
    }
  }
}
