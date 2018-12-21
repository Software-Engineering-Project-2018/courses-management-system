import { BaseObject } from './base-object';
import { CourseObject } from './Course-object';

export class NotificationObject extends BaseObject {
    NotificationId: number;
    NotificationName: string;
    NotificatonDateCreate: Date;
    NotificationCreatorName: string;
    NotificationContent: string;
    NotificationType: number; // 1: general notification or 2: course notification
    Course: CourseObject;
    public constructor() {
        super();
        this.Course = new CourseObject();
    }
}
