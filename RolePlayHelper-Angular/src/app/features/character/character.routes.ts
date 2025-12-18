import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'create-character',
    loadComponent: () =>
      import('./pages/create-character/create-character').then((c) => c.CreateCharacter),
  },
  {
    path: 'list-public-character',
    loadComponent: () =>
      import('./pages/character-public-list/character-public-list').then(
        (c) => c.CharacterPublicList,
      ),
  },
];
