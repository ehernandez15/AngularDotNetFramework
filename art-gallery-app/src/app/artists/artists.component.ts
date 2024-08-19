import { Component,inject } from '@angular/core';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common'; 
import { ArtistDTO } from '../../models/artistDTO';

@Component({
  selector: 'app-artists',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './artists.component.html',
  styleUrl: './artists.component.css'
})
export default class ArtistsComponent {

  public apiService = inject(ApiService);

  artistsList: ArtistDTO[] = [];

  constructor(){
    this.getArtists();
  }

  getArtists(){
    this.apiService.getArtists().subscribe(
      (data:ArtistDTO[]) => {
        this.artistsList = data;
      },
      (error) => {
        console.error('Error fetching artists:', error);
      }
    )
  }

}
