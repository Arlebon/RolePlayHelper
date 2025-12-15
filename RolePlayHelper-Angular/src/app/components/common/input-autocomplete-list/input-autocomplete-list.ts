import { Component, input, output } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { timeout } from 'rxjs';

@Component({
  selector: 'app-input-autocomplete-list',
  imports: [ReactiveFormsModule],
  templateUrl: './input-autocomplete-list.html',
  styleUrl: './input-autocomplete-list.scss',
})
export class InputAutocompleteList {
  elements = input.required<
    {
      id: number;
      name: string;
    }[]
  >();
  formControl = input.required<FormControl>();

  clickSelect = output<number>();

  touched: boolean = false;

  onClickSelect(id: number) {
    this.clickSelect.emit(id);
  }
}
