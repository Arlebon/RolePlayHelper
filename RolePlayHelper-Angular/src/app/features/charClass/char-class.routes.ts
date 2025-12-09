import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./pages/char-class-listing-page/char-class-listing-page').then(
        (c) => c.CharClassListingPage,
      ),
  },
];
