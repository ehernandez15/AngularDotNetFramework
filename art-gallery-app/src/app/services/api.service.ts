import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ArtistDTO } from '../../models/artistDTO';
import { ArtworkDTO } from '../../models/artworkDTO';
import { GalleryDTO } from '../../models/galleryDTO';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private http = inject(HttpClient);

  private artistsApiUrl = 'https://localhost:44366/api/Artists';
  private artworksApiUrl = 'https://localhost:44366/api/Artworks';
  private galleriesApiUrl = 'https://localhost:44366/api/Galleries';

  constructor() {}

  getArtists(): Observable<ArtistDTO[]>{
    return this.http.get<any>(this.artistsApiUrl);
  }

  getArtworks(): Observable<ArtworkDTO[]>{
    return this.http.get<any>(this.artworksApiUrl);
  }

  getGalleries(): Observable<GalleryDTO[]>{
    return this.http.get<any>(this.galleriesApiUrl);
  }


}
