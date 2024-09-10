import styles from "./styles.module.css"
import { useFormik } from 'formik';


function Login() {
    const formik = useFormik({
        initialValues:{
            email:"",
            password:""
        },
        onSubmit: (values) => {console.log(values) }
    });

  return (
    <div>
    <form onSubmit={formik.handleSubmit} className={styles.form}>
    <h1>SES HUKUK PANEL GİRİŞ</h1>
        <div className={styles.email}>
            <label>Email:</label>
            <br/>
            <input className={styles.input} type = "email" name="email" onChange={formik.handleChange} value={formik.values.email}></input>
        </div>
        <div className={styles.password}>
            <label>Şifre:</label>
            <br/>
            <input className={styles.input} type = "password" name="password" onChange={formik.handleChange} value={formik.values.password}></input>
        </div>
        <div className={styles.btn}>
        <button type="submit">Giriş Yap</button>
        </div>
    </form>
        
        </div>
  )
}

export default Login