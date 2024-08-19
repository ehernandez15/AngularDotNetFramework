import { ArtworkDTO } from "./artworkDTO";

export interface GalleryDTO {
    Id: number;
    GalleryName: string;
    GalleryAddress: string;
    GalleryDateOfEstablishment?: Date; // Optional
    GalleryDescription?: string; // Optional
  
    // This could be a list of artworks or could be omitted if not needed
    Exhibited_Artworks?: ArtworkDTO[]; // Optional
  }
  