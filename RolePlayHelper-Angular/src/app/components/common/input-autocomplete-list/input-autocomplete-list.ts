import { Component, forwardRef, input, output } from '@angular/core';
import { FormControl, FormsModule, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-input-autocomplete-list',
  imports: [FormsModule],
  templateUrl: './input-autocomplete-list.html',
  styleUrl: './input-autocomplete-list.scss',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputAutocompleteList),
      multi: true,
    },
  ],
})
export class InputAutocompleteList {
  elements = input.required<
    {
      id: number;
      name: string;
    }[]
  >();
  formControl = input.required<FormControl>();

  textTyped = output<string>();

  inputTextValue: string = '';
  touched: boolean = false;
  timer: any;

  onClickSelect(id: number) {
    // this.clickSelect.emit(id);
    this.formControl().setValue(id);
    this.inputTextValue = this.elements().find((e) => e.id === id)?.name ?? '';
    this.textTyped.emit(this.inputTextValue);
  }

  onTextTyped() {
    let timer: any;
    clearTimeout(timer);
    timer = setTimeout(() => {
      this.touched = true;
      this.textTyped.emit(this.inputTextValue);
    }, 400);
  }
}
