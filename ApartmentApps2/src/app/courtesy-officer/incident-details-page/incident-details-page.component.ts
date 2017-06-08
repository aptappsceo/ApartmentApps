import { Component, OnInit } from '@angular/core';
import { CourtesyClient, IncidentReportBindingModel } from 'app/aaservice-module/aaclient';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-incident-details-page',
  templateUrl: './incident-details-page.component.html',
  styleUrls: ['./incident-details-page.component.css']
})
export class IncidentDetailsPageComponent implements OnInit {
  model: IncidentReportBindingModel;

  constructor(private courtesyService: CourtesyClient, private route: ActivatedRoute) { }

  ngOnInit() {
      this.route.params.subscribe(params => {
          let id = +params['id'];
          this.courtesyService.get(id).subscribe(x => {
              this.model = x;
          });
      });
  }

}
