import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'planet-explorations',
  standalone: true,
  imports: [],
  templateUrl: './planet-explorations.component.html',
  styleUrl: './planet-explorations.component.css'
})
export class PlanetExplorationsComponent implements OnInit {
  
    constructor(private httpClient: HttpClient) { }
  
    ngOnInit() {
      this.httpClient.get('https://localhost:44373/planet-explorations')
        .subscribe(data => { console.log(data) });
    }
}
