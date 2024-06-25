
import { User } from './user.model';

export interface Task {
  id: number;
  userId: number;
  subject: string;
  targetDate: Date;
  isCompleted: boolean;
  user?: User; // הוספת השדה user
}
