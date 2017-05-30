import {Component, Input, forwardRef} from "@angular/core";
import {ControlValueAccessor, NG_VALUE_ACCESSOR} from "@angular/forms";
import {NavController, ActionSheetController, ModalController} from "ionic-angular";
import {Camera} from "ionic-native";
import * as _ from 'lodash';
import {FullscreenImagePage} from "../../pages/fullscreen-image-page/fullscreen-image.page";
import {LoadingService} from "../../services/loading.service";
import {ToastService} from "../../services/toast.service";
@Component({
  templateUrl: "section-photos.component.html",
  selector: 'section-photos-component',
  providers: [{
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => SectionPhotosComponent),
    multi: true
  }],
})
export class SectionPhotosComponent implements ControlValueAccessor {

  constructor(public actionSheetCtrl: ActionSheetController,
              public navCtrl: NavController,
              public modalCtrl: ModalController,
              public loadingService: LoadingService,
              public toastService: ToastService) {
  }

  @Input() public startActive: boolean = false;
  @Input() public placeholderTitle: string;
  @Input() public placeholderActionTitle: string;
  @Input() public placeholderIcon: string;
  @Input() public sectionTitle: string;

  public isActive: boolean;

  public resources: string[] = [];

  private propagateChange: any;


  public get value(): string[] {
    return this.resources;
  }

  public set value(val: string[]) {
    if (val && val.length > 0) {
      this.isActive = true;
    } else {
      this.isActive = false;
    }
    this.resources = val;
    if (this.propagateChange) this.propagateChange(this.resources);
  }


  public ngOnInit(): void {
    this.isActive = this.startActive;
  }

  public onActivate(): void {
    this.openResourceSelection();
  }

  public writeValue(value: any): void {
    if (value && value !== this.resources) {
      this.resources = value;
    }
    if (!value) {
      this.resources = [];
    }
  }

  public registerOnChange(fn: any): void {
    this.propagateChange = fn;
  }

  public registerOnTouched(fn: any): void {
  }

  public modifyResource(resource: string) {

    let actionSheet = this.actionSheetCtrl.create({
      title: 'Select photo source',
      buttons: [
        {
          text: 'View',
          handler: () => {
            let modal = this.modalCtrl.create(FullscreenImagePage, {
              resource: resource
            });
            modal.present();
          }
        },
        {
          text: 'Remove',
          role: 'destructive',
          handler: () => {
            this.value = _.filter(this.resources, r => r != resource);
          }
        },
        {
          text: 'Cancel',
          role: 'cancel',
          handler: () => {
          }
        }
      ]
    });
    actionSheet.present();

  }

  public openResourceSelection() {

    this.selectResourceSource()
      .then(source => this.selectPhoto(source))
      .then(data => this.convertBase64Resource(data))
      .then(resource => this.value = _.concat(this.resources, [resource]))
      .catch(er => {
        this.toastService.show("Unable to attach photo.");
        console.error(er);
      });
  }


  public selectPhoto(sourceType: number): Promise<any> {

    return Camera.getPicture({
      sourceType: sourceType,
      allowEdit: false,
      destinationType: Camera.DestinationType.DATA_URL,
      mediaType: Camera.MediaType.PICTURE,
      correctOrientation: true
    });


  }

  public convertBase64Resource(data: string): Promise<string> {

    return Promise.resolve('data:image/jpeg;base64,' + data);
  }

  public selectResourceSource(): Promise<number> {
    return new Promise<number>((res, rej) => {
      let actionSheet = this.actionSheetCtrl.create({
        title: 'Select photo source',
        buttons: [
          {
            text: 'Camera',
            handler: () => {
              res(Camera.PictureSourceType.CAMERA);
            }
          },
          {
            text: 'Gallery',
            handler: () => {
              res(Camera.PictureSourceType.PHOTOLIBRARY);
            }
          },
          {
            text: 'Photo Album',
            handler: () => {
              res(Camera.PictureSourceType.SAVEDPHOTOALBUM);
            }
          },
          {
            text: 'Cancel',
            role: 'cancel',
            handler: () => {
              rej();
            }
          }
        ]
      });
      actionSheet.present();
    });
  }


}
