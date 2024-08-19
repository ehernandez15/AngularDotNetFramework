import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-artists',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './artists.component.html',
  styleUrl: './artists.component.css'
})
export default class ArtistsComponent {

}
