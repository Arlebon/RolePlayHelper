import { ChangeDetectorRef, Component, inject, OnInit, signal, Signal } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { RaceListCreateChar } from '@core/models/race/race-list-create-char.model';
import { RaceService } from 'src/app/services/race-service';
import { InputAutocompleteList } from '@components/common/input-autocomplete-list/input-autocomplete-list';
import { CharClassListCreateChar } from '@core/models/char-class/char-class-list-create-char.model';
import { CharClassService } from 'src/app/services/char-class-service';
import { CharacterService } from 'src/app/services/character-service';

@Component({
  selector: 'app-create-character',
  imports: [ReactiveFormsModule, InputAutocompleteList],
  templateUrl: './create-character.html',
  styleUrl: './create-character.scss',
})
export class CreateCharacter implements OnInit {
  private readonly _fb = inject(FormBuilder);
  private readonly _raceService = inject(RaceService);
  private readonly _classService = inject(CharClassService);
  private readonly _charService = inject(CharacterService);

  constructor(private cdr: ChangeDetectorRef) {}

  availablePoints: number = 27;
  races: RaceListCreateChar[] = [];
  classes: CharClassListCreateChar[] = [];
  invalidRace: boolean = true;
  createError: string = '';

  name = new FormControl('', [Validators.required, Validators.min(2), Validators.max(50)]);
  race = new FormControl(null, [Validators.required]);
  class = new FormControl(null, [Validators.required]);
  str = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  dex = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  cha = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  int = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  con = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);
  wis = new FormControl(8, [Validators.required, Validators.min(8), Validators.max(15)]);

  characterCreaterForm = this._fb.group({
    name: this.name,
    race: this.race,
    class: this.class,
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
    this._classService.getClassesCharCreate().then((data) => {
      this.classes = data;
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
    if (this.characterCreaterForm.valid) {
      const charClassIdsTemp: number[] = [];
      charClassIdsTemp.push(this.characterCreaterForm.value.class!);

      this._charService
        .createChar({
          name: this.characterCreaterForm.value.name!,
          raceId: this.characterCreaterForm.value.race!,
          charClassIds: charClassIdsTemp,
          str: this.characterCreaterForm.value.str!,
          dex: this.characterCreaterForm.value.dex!,
          cha: this.characterCreaterForm.value.cha!,
          int: this.characterCreaterForm.value.int!,
          con: this.characterCreaterForm.value.con!,
          wis: this.characterCreaterForm.value.wis!,
        })
        .then(() => console.log('Creation success'))
        .catch((err) => {
          console.error(err);
          this.createError = err.message;
        });
    }
  }

  loadRaceFilter(filter: string) {
    this._raceService.getSomeByName(filter).then((data) => {
      if (data.length == 0) {
        this.invalidRace = true;
      } else {
        this.races = data;
        this.invalidRace = false;
        if (this.races.find((r) => r.name == filter) === undefined) {
          this.invalidRace = true;
        }
      }
      this.cdr.markForCheck();
    });
  }

  loadClassFilter(filter: string) {
    this._classService.getSomeByNameCharCreate(filter).then((data) => {
      if (data.length == 0) {
        this.invalidRace = true;
      } else {
        this.classes = data;
        this.invalidRace = false;
        if (this.classes.find((c) => c.name == filter) === undefined) {
          this.invalidRace = true;
        }
      }
      this.cdr.markForCheck();
    });
  }
}
