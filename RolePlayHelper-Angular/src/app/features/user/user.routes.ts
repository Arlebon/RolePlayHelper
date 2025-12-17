import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'characters',
    loadComponent: () =>
      import('./pages/list-character-page/list-character-page').then((c) => c.ListCharacterPage),
  },
];
