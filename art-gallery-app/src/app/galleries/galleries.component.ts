import { Component,inject } from '@angular/core';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common'; 
import { GalleryDTO } from '../../models/galleryDTO';

@Component({
  selector: 'app-galleries',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './galleries.component.html',
  styleUrl: './galleries.component.css'
})
export default class GalleriesComponent {

  public apiService = inject(ApiService);

  galleriesList: GalleryDTO[] = [];

  constructor(){
    this.getGalleries();
  }

  getGalleries(){
    this.apiService.getGalleries().subscribe(
      (data:GalleryDTO[]) => {
        this.galleriesList = data;
      },
      (error) => {
        console.error('Error fetching galleries:', error);
      }
    )
  }

}
