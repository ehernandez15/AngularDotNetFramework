import { Component,inject } from '@angular/core';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common'; 
import { ArtworkDTO } from '../../models/artworkDTO';

@Component({
  selector: 'app-artworks',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './artworks.component.html',
  styleUrl: './artworks.component.css'
})
export default class ArtworksComponent {

  public apiService = inject(ApiService);

  artworksList: ArtworkDTO[] = [];

  constructor(){
    this.getArtworks();
  }

  getArtworks(){
    this.apiService.getArtworks().subscribe(
      (data:ArtworkDTO[]) => {
        this.artworksList = data;
      },
      (error) => {
        console.error('Error fetching artworks:', error);
      }
    )
  }
}
