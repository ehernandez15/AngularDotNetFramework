import { Component,inject } from '@angular/core';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common'; 
import { ArtistDTO } from '../../models/artistDTO';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {ReactiveFormsModule} from '@angular/forms'

@Component({
  selector: 'app-artists',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './artists.component.html',
  styleUrl: './artists.component.css'
})
export default class ArtistsComponent {

  public apiService = inject(ApiService);

  artistsList: ArtistDTO[] = [];
  artistForm: FormGroup;
  showForm: boolean = false;

  constructor(private fb: FormBuilder){
    this.getArtists();

    this.artistForm = this.fb.group({
      artistName: ['', Validators.required],
      artistBio: ['', Validators.required],
      artistBirthDate: ['', Validators.required],
      artistDeathDate: ['', Validators.required],
      artistNationality: ['', Validators.required],
    });
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

  createArtist(artist:ArtistDTO){
   this.apiService.createArtists(artist).subscribe(
    (data:ArtistDTO) => {
      this.getArtists();
      this.showForm = false;
    },
    (error) => {
      console.error('Error creating an artist:', error);
    }
   ) 
  }

  onSubmit(): void {
    if (this.artistForm.valid) {
      const formValue = this.artistForm.value;
      let artistDTO: ArtistDTO = {
        Id: 0,
        Artist_Name : formValue?.artistName,
        Artist_BirthDate: formValue?.artistBirthDate,
        Artist_DeathDate: formValue?.artistDeathDate, 
        Artist_Biography: formValue?.artistBio,
        Artist_Nationality: formValue?.artistNationality
      }
      
      this.createArtist(artistDTO);
    }
  }

  onAddArtist():void {
    this.artistForm.reset();
    this.showForm = true;
  }

  onCancel():void{
    this.artistForm.reset();
    this.showForm = false;
  }

}
