import styles from "./styles.module.css"
import { useFormik } from "formik";
import { postContactForm } from "../../api";
import 'react-notifications/lib/notifications.css';
import {NotificationContainer, NotificationManager} from 'react-notifications';
import contactFormSchema from "../../validation";

function ContactForm() {
    const formik = useFormik({
        initialValues:{
            fullName:"",
            email:"",
            phone:"",
            message:""
        },
        onSubmit: async (values) => {
            try{
            var data = await postContactForm(values) ;

                 if(data.isSuccess){
                        formik.values.fullName = '';
                        formik.values.email = '';
                        formik.values.phone = '';
                        formik.values.message = '';

                        NotificationManager.success('Mesajınız başarıyla gönderildi', 'Başarılı', 3000);
                    }
            }
            catch(ex){
                console.log(JSON.stringify(ex.response.data.errors));
                NotificationManager.error(`${JSON.stringify(ex.response.data.errors)}`, 'Hata');
            }
        },
        validationSchema: contactFormSchema
    });

    for(let key in formik.touched){
        if(formik.touched[key]){
                NotificationManager.error(`${formik.errors[key]}`, 'Hata');
        }
    }

  return (
    <div className={styles.contactForm}>
        <form onSubmit={formik.handleSubmit}>
            <h1>İLETİŞİM FORMU</h1>
            <div className={styles.input}>
                <span>İsim:</span>
                <br />
                <input name="fullName" type="text" value={formik.values.fullName} onChange={formik.handleChange} onBlur={formik.handleBlur}></input>
            </div>
            <div className={styles.input}>
                <span>Email:</span>
                <br />
                <input name="email" type="email" value={formik.values.email} onChange={formik.handleChange} onBlur={formik.handleBlur}></input>
            </div>
            <div className={styles.input}>
                <span>Telefon Numarası:</span>
                <br />
                <input name="phone" type="phone" value={formik.values.phone} onChange={formik.handleChange} onBlur={formik.handleBlur}></input>
            </div>
            <div className={styles.input}>
                <span>Mesaj:</span>
                <br />
                <textarea name="message" type="text" value={formik.values.message} onChange={formik.handleChange} onBlur={formik.handleBlur} rows={"10"}></textarea>
            </div>
            <div className={styles.submitButton}>
            <button type="submit">GÖNDER</button>
            </div>
        </form>

        <NotificationContainer />
    </div>
  )
}

export default ContactForm