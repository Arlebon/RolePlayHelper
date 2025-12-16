import { Component, forwardRef, input, output } from '@angular/core';
import { ControlValueAccessor, FormControl, FormsModule, NG_VALUE_ACCESSOR } from '@angular/forms';

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
export class InputAutocompleteList implements ControlValueAccessor {
  elements = input.required<
    {
      id: number;
      name: string;
    }[]
  >();

  writeValue(value: number | null): void {
    this.selectedId = value;

    const name = value == null ? '' : (this.elements().find((e) => e.id === value)?.name ?? '');

    this.inputTextValue = name;
  }

  registerOnChange(fn: (value: number | null) => void): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: () => void): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  selectedId: number | null = null;
  disabled = false;
  onChange: (value: number | null) => void = () => {};
  onTouched: () => void = () => {};

  formControl = input.required<FormControl>();

  textTyped = output<string>();
  inputTextValue: string = '';
  touched: boolean = false;
  timer: any;

  onClickSelect(id: number) {
    if (this.disabled) return;

    this.selectedId = id;
    this.inputTextValue = this.elements().find((e) => e.id === id)?.name ?? '';

    this.onChange(id); // <-- CVA updates parent form control
    this.onTouched(); // <-- mark as touched
    this.textTyped.emit(this.inputTextValue);
    this.touched = false; // close list after selection
  }

  onTextTyped() {
    let timer: any;
    clearTimeout(timer);
    timer = setTimeout(() => {
      this.touched = true;
      this.textTyped.emit(this.inputTextValue);
    }, 400);
  }

  onFocus() {
    if (this.disabled) return;
    this.touched = true;
  }

  onBlur() {
    this.touched = false;
    this.onTouched();
  }
}
