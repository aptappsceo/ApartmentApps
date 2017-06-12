import { Component, OnInit } from '@angular/core';
import { CourtesyClient, IncidentReportBindingModel, IncidentCheckinBindingModel } from 'app/aaservice-module/aaclient';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-incident-details-page',
  templateUrl: './incident-details-page.component.html',
  styleUrls: ['./incident-details-page.component.scss']
})
export class IncidentDetailsPageComponent implements OnInit {
  model: IncidentReportBindingModel;

  constructor(private courtesyService: CourtesyClient, private route: ActivatedRoute) { }
  getImages(checkin: IncidentCheckinBindingModel): string[] {
    let result = [];
    for (let i = 0 ; i < checkin.photos.length; i++) {
        result.push(checkin.photos[i].thumbnailUrl);
    }
    return result;
  }
  ngOnInit() {
      this.route.params.subscribe(params => {
          let id = +params['id'];
          this.courtesyService.get(id).subscribe(x => {
              this.model = x;

          });
      });
  }

}
