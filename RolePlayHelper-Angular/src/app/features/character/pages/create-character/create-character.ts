import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { RaceListCreateChar } from '@core/models/race/race-list-create-char.model';

@Component({
  selector: 'app-create-character',
  imports: [ReactiveFormsModule],
  templateUrl: './create-character.html',
  styleUrl: './create-character.scss',
})
export class CreateCharacter implements OnInit {
  private readonly _fb = inject(FormBuilder);

  availablePoints: number = 27;
  races: RaceListCreateChar[] = [];

  name = new FormControl('', [Validators.required, Validators.min(2), Validators.max(50)]);
  str = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  dex = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  cha = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  int = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  con = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  wis = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);

  characterCreaterForm = this._fb.group({
    name: this.name,
    str: this.str,
    dex: this.dex,
    cha: this.cha,
    int: this.int,
    con: this.con,
    wis: this.wis,
  });

  ngOnInit(): void {}

  onChange() {
    this.availablePoints = 27;
    this.availablePoints =
      this.availablePoints -
      this.str.value! +
      8 -
      this.dex.value! +
      8 -
      this.cha.value! +
      8 -
      this.int.value! +
      8 -
      this.con.value! +
      8 -
      this.wis.value! +
      8;
    console.log(this.availablePoints);
  }
}
