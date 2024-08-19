import { Component, inject } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-galleries',
  standalone: true,
  imports: [],
  templateUrl: './galleries.component.html',
  styleUrl: './galleries.component.css'
})
export default class GalleriesComponent {

  public apiService = inject(ApiService);

  constructor(){
    console.log(this.apiService.getArtists())
  }

}
