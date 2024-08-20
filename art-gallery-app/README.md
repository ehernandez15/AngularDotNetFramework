### Step 4: ArtGalleryApp

##### Step 4.1: Creating the Angular project

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 17.3.8.

Run the following commands in your terminal. 

    ng new art-gallery-app
    cd art-gallery-app
    ng serve

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

##### 4.2: Creating the components 

Create the following components: 

    ng generate component artists
    ng generate component artworks
    ng generate component galleries
    ng generate component home


Create the service to consume the backend APIs
    
    ng generate service services/api

##### 4.3: Route the componets

Configure the Routes values in app.routes.ts with the following configuration. 

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

