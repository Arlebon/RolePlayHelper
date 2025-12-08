import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./pages/language-list-page/language-list-page').then((c) => c.LanguageListPage),
  },
];
