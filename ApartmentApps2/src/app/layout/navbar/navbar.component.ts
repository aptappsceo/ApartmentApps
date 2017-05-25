import { Component, EventEmitter, OnInit, ElementRef, Output, Inject } from '@angular/core';
import { AppConfig } from '../../app.config';
import { UserContext } from '../../aaservice-module/usercontext';
import { UserInfoViewModel } from 'app/aaservice-module/aaclient';
import { UserService } from '../../aaservice-module/user.service';
import { ModuleInfo } from '../../aaservice-module/aaclient';

declare let jQuery: any;

@Component({
  selector: '[navbar]',
  templateUrl: './navbar.template.html'
})
export class Navbar implements OnInit {
  public userInfo: ModuleInfo = new ModuleInfo();
  @Output() toggleSidebarEvent: EventEmitter<any> = new EventEmitter();
  @Output() toggleChatEvent: EventEmitter<any> = new EventEmitter();
  $el: any;
  config: any;
  moduleInfo: ModuleInfo = new ModuleInfo();
  constructor(private userService: UserService, el: ElementRef, config: AppConfig) {
    this.$el = jQuery(el.nativeElement);
    this.config = config.getConfig();

  }

  toggleSidebar(state): void {
    this.toggleSidebarEvent.emit(state);
  }

  toggleChat(): void {
    this.toggleChatEvent.emit(null);
  }


  ngOnInit(): void {
    this.userService.RequestUserInfo()
      .then(x => { this.userInfo = x.propertyConfig.moduleInfo; });

    setTimeout(() => {
      let $chatNotification = jQuery('#chat-notification');
      $chatNotification.removeClass('hide').addClass('animated fadeIn')
        .one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', () => {
          $chatNotification.removeClass('animated fadeIn');
          setTimeout(() => {
            $chatNotification.addClass('animated fadeOut')
              .one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd' +
                ' oanimationend animationend', () => {
                $chatNotification.addClass('hide');
              });
          }, 8000);
        });
      $chatNotification.siblings('#toggle-chat')
        .append('<i class="chat-notification-sing animated bounceIn"></i>');
    }, 4000);

    this.$el.find('.input-group-addon + .form-control').on('blur focus', function(e): void {
      jQuery(this).parents('.input-group')
        [e.type === 'focus' ? 'addClass' : 'removeClass']('focus');
    });
  }
}
