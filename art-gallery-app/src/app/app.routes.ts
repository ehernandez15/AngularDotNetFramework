import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'artists',
        loadComponent: () => import('./artists/artists.component'),
        children: []
    },
    {
        path: 'artworks',
        loadComponent: () => import('./artworks/artworks.component'),
        children: []
    },
    {
        path: 'galleries',
        loadComponent: () => import('./galleries/galleries.component'),
        children: []
    },
    {
        path: '',
        loadComponent: () => import('./home/home.component'),
        pathMatch: 'full'
    }
];
