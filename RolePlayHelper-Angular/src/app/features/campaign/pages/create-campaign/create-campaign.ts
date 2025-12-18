import { Component, inject } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-campaign',
  imports: [ReactiveFormsModule],
  templateUrl: './create-campaign.html',
  styleUrl: './create-campaign.scss',
})
export class CreateCampaign {
  private readonly _fb = inject(FormBuilder);

  name = new FormControl('', [
    Validators.required,
    Validators.minLength(5),
    Validators.maxLength(255),
  ]);
  nbPlayers = new FormControl(2, [Validators.required, Validators.min(2), Validators.max(8)]);

  campaignCreateForm = this._fb.group({
    name: this.name,
    nbPlayers: this.nbPlayers,
  });
}
