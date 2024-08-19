export interface ArtworkDTO {
    Id: number;
    Name: string;
    CreationDate?: Date; // Optional
    Type: string;
    Description?: string; // Optional
    Gallery_Code?: number; // Optional
    Artist_Code?: number; // Optional
    EstimatedValue?: number; // Optional
  }