# Task Manager

ברוכים הבאים לפרויקט **Task Manager**! 

זהו יישום לניהול משימות עם צד שרת מבוסס **.NET Core** וצד לקוח מבוסס **Angular**.

---

## 🚀 התקנה והרצה

### צד שרת (Backend)

1. יש להוריד את הפרויקט מ-GitHub:
   ```sh
   git clone https://github.com/extremeCase/TaskManagerServer.git
   ```
2. יש לפתוח את הקובץ `TaskManager.sln` באמצעות **Visual Studio** ולהריץ את הפרויקט.

---

### צד לקוח (Frontend)

#### ✅ הרצה באמצעות StackBlitz (ללא התקנה מקומית)
לגישה מהירה, ניתן לפתוח את הפרויקט ישירות ב-StackBlitz:  
🔗 **[StackBlitz - Task Manager Client](https://stackblitz.com/~/github.com/extremeCase/tasks-manager-client?file=src/environments/environment.ts:L10)**

#### 💻 הרצה מקומית
1. יש להוריד את הפרויקט מ-GitHub:
   ```sh
   git clone https://github.com/extremeCase/tasks-manager-client.git
   ```
2. יש להיכנס לתיקיית הפרויקט ולהתקין את התלויות:
   ```sh
   cd tasks-manager-client
   npm install
   ```
3. יש להפעיל את השרת המקומי:
   ```sh
   ng serve
   ```
4. היישום יהיה זמין בכתובת:  
   🌍 **[http://localhost:4200](http://localhost:4200)**
5. יש לוודא שקובץ `environment.ts` מוגדר כך שה-Frontend יתחבר לכתובת שבה ה-Backend רץ, לדוגמה:
   ```typescript
   export const environment = {
     production: false,
     apiUrl: 'http://localhost:5000/api' // יש לוודא שכתובת זו תואמת לשרת המקומי
   };
   ```

---

## 🛠️ טכנולוגיות עיקריות
- **Backend**: .NET Core
- **Frontend**: Angular
- **Styles**: Bootstrap 5

---

## 📌 הערות נוספות
- יש לוודא שה-Backend פועל לפני הפעלת ה-Frontend כדי למנוע שגיאות חיבור.
- הפרויקט בנוי לפי **Best Practices** בארכיטקטורת Angular ו-.NET.
- במקרה של בעיות התקנה, יש לבדוק שהתלויות מותקנות כראוי.

---

📌 **בהצלחה!** 🚀

