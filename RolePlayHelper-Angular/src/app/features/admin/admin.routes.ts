import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'char-class/create',
    loadComponent: () =>
      import('../admin/char-class-create-page/char-class-create-page').then(
        (c) => c.CharClassCreatePage,
      ),
  },
  {
    path: 'language/create',
    loadComponent: () =>
      import('../admin/language-create-page/language-create-page').then(
        (c) => c.LanguageCreatePage,
      ),
  },
  {
    path: 'race-trait/create',
    loadComponent: () =>
      import('../admin/race-trait-create-page/race-trait-create-page').then(
        (c) => c.RaceTraitCreatePage,
      ),
  },
  {
    path: 'race/create',
    loadComponent: () =>
      import('../admin/race-create-page/race-create-page').then((c) => c.RaceCreatePage),
  },
];
