import { Component ,inject} from '@angular/core';
import { CommonModule } from '@angular/common';
import { HousingLocationComponent } from '../housing-location/housing-location.component';
import { HousingService } from '../housing.service';
import { HousingLocation } from '../housinglocation';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,HousingLocationComponent],
  template: `
  <app-housing-location
  *ngFor="let housingLocation of housingLocationList"
  [housingLocation]="housingLocation">
</app-housing-location>
  `,
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  housingLocationList:HousingLocation[]=[];
  housingService: HousingService = inject(HousingService);

  constructor() {
    this.housingLocationList = this.housingService.getAllHousingLocations();
  }
}
