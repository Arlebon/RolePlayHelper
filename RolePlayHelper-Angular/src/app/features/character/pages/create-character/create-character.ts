import { ChangeDetectorRef, Component, inject, OnInit, signal, Signal } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { RaceListCreateChar } from '@core/models/race/race-list-create-char.model';
import { RaceService } from 'src/app/services/race-service';
import { InputAutocompleteList } from '@components/common/input-autocomplete-list/input-autocomplete-list';

@Component({
  selector: 'app-create-character',
  imports: [ReactiveFormsModule, InputAutocompleteList],
  templateUrl: './create-character.html',
  styleUrl: './create-character.scss',
})
export class CreateCharacter implements OnInit {
  private readonly _fb = inject(FormBuilder);
  private readonly _raceService = inject(RaceService);

  constructor(private cdr: ChangeDetectorRef) {}

  availablePoints: number = 27;
  races: RaceListCreateChar[] = [];
  invalidRace: boolean = false;

  name = new FormControl('', [Validators.required, Validators.min(2), Validators.max(50)]);
  race = new FormControl('', [Validators.required]);
  str = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  dex = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  cha = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  int = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  con = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  wis = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);

  characterCreaterForm = this._fb.group({
    name: this.name,
    race: this.race,
    str: this.str,
    dex: this.dex,
    cha: this.cha,
    int: this.int,
    con: this.con,
    wis: this.wis,
  });

  ngOnInit(): void {
    this._raceService.getAllForCreateChar().then((data) => {
      this.races = data;
      this.cdr.markForCheck();
    });
    console.log(this.races);
  }

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

  onSubmit() {
    this.cdr.markForCheck();
    if (this.races.find((r) => r.name === this.characterCreaterForm.value.race!)?.id != undefined) {
      console.log(this.characterCreaterForm);
    }
  }

  onRaceClick(id: number) {
    this._raceService.getOneById(id).then((data) => {
      this.race.setValue(data.name);
      this.invalidRace = false;
      this.loadFilter(this.race.value!);
    });
  }

  loadFilter(filter: string) {
    this._raceService.getSomeByName(filter).then((data) => {
      if (data.length == 0) {
        this.invalidRace = true;
      } else {
        this.races = data;
        this.invalidRace = false;
      }
      this.cdr.markForCheck();
    });
  }
}
