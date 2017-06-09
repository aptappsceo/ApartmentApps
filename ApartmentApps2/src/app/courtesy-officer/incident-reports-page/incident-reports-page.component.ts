import { NotificationsService } from 'angular2-notifications';
import { Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { CourtesyClient, IncidentIndexBindingModel, Query, SearchEnginesClient, IncidentReportViewModel, Navigation, Search, FilterData, ClientSearchModel, LookupsClient } from 'app/aaservice-module/aaclient';
import { CommentItem } from "app/widgets/comment-item/comment-item.component";
import { SearchPanelComponent } from '../../aacore/search-panel/search-panel.component';


@Component({
  selector: 'app-incident-reports-page',
  templateUrl: './incident-reports-page.component.html',
  styleUrls: ['./incident-reports-page.component.css']
})
export class IncidentReportsPageComponent implements OnInit {
  totalRecords: number;
  @ViewChildren(SearchPanelComponent) searchComponents: QueryList<SearchPanelComponent>;
  searchModel: ClientSearchModel;
  incidents: IncidentReportViewModel[];
  query: Query = new Query() ;
  engineId: string = 'IncidentReport';
  page: Number = 1;
  constructor( private searchEngine: SearchEnginesClient,
  private officerClient: CourtesyClient, private lookupsClient: LookupsClient, private notify: NotificationsService) {
    this.query.navigation = new Navigation();
    this.query.navigation.skip = 0;
    this.query.navigation.take = 5;

    this.query.search = new Search();
    this.query.search.engineId = this.engineId;
  }

onChangeTable(config, $event) {
  this.query.navigation.skip = ($event.page - 1) * this.query.navigation.take;
  console.log(config, $event, this.query.navigation);
  this.reloadData();
}
filtersUpdate() {
  this.reloadData();
}
  reloadData() {
    let items = this.searchComponents
      .filter((x, i) => x.value != null && x.active)
      .map(x => x.filterData);
    console.log('ITEMS', items);
    this.query.search.filters = items;
    this.officerClient.fetch(this.query).subscribe( x => {
      this.incidents = x.result;
      this.totalRecords = x.total;
      console.log('fetch', x.result);
    });
  }
  ngOnInit() {

     this.searchEngine.getSearchModel(this.engineId)
          .subscribe(x => {
              this.searchModel = x.model;
               this.reloadData();
          });
  }
  getImages(incident: IncidentReportViewModel): string[] {
    let result = [];
    for (let i = 0 ; i < incident.checkins.length; i++) {
      for (let x = 0; x < incident.checkins[i].photos.length; x++ ) {
        result.push(incident.checkins[i].photos[i].url);
      }
    }
    return result;
  }
  mapComments(incident: IncidentReportViewModel): CommentItem[] {
    return incident.checkins.map(x => {
      let cmt = new CommentItem();

      cmt.comment = x.comments;
      cmt.time = x.date.toDateString();
      cmt.userInfo = x.officer;
      return cmt;
    });

  }
}
