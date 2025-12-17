import { Component, inject } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { CharClassCreateModel } from '@core/models/char-class/char-class-create.model';
import { CharClassListModel } from '@core/models/char-class/char-class-list-model';
import { CharClassService } from 'src/app/services/char-class-service';

@Component({
  selector: 'app-char-class-create-page',
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './char-class-create-page.html',
  styleUrl: './char-class-create-page.scss',
})
export class CharClassCreatePage {
  private readonly _fb = inject(FormBuilder);
  private readonly _charClassService = inject(CharClassService);
  private readonly _router = inject(Router);

  classList: CharClassListModel[] = [];

  isSubClass: boolean = false;

  classForm: FormGroup = this._fb.group({
    name: ['', Validators.required],
    description: [''],
    parentClassId: [null],
  });

  ngOnInit(): void {
    this._charClassService.getClasses().then((data) => {
      this.classList = data;
    });
  }

  onToggleSubclass() {
    const parentControl = this.classForm.get('parentClassId');

    if (this.isSubClass) {
      parentControl?.setValidators([Validators.required]);
    } else {
      parentControl?.clearValidators();
      parentControl?.setValue(null);
    }

    parentControl?.updateValueAndValidity();
  }

  onSubmit() {
    if (this.classForm.invalid) {
      this.classForm.markAllAsTouched();
      return;
    }

    const charClass: CharClassCreateModel = {
      name: this.classForm.value.name,
      description: this.classForm.value.description,
      parentClassId: this.isSubClass ? this.classForm.value.parentClassId : null,
    };

    console.log('class:', charClass);

    this._charClassService.CreateCharClass(charClass).then(() => {
      this._router.navigate(['/char-class']);
    });
  }
}
