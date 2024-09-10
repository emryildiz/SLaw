import styles from "./styles.module.css"
import { RiPhoneFill, RiMailFill, RiHome3Fill } from "react-icons/ri";

function Footer() {
  return (
    <div className={styles.footer}>
      <div className={styles.information}>
        <h1>SES HUKUK</h1>
        <p>Büromuz avukatlık ve danışmanlık hizmetini Avukatlık Meslek İlkeleri’ne ve Avrupa Birliği Avukatlık Meslek Kuralları’na uygun olarak icra etmeyi prensip edinmiştir.</p>
      </div>
      <div className={styles.contact}>
        <h1>İLETİŞİM BİLGİLERİ</h1>
        <div>
        <span><RiPhoneFill/> +90 (555) 555 55 55</span>
        <span><RiPhoneFill/> +90 (555) 555 55 55</span>
        <span><RiMailFill/> deneme@seshukuk.com.tr</span>
        <span><RiMailFill/> deneme@seshukuk.com.tr</span>
        <span><RiHome3Fill/> Panayır Mah. İstanbul Cad. No: 387 Biçen Plaza K: 12 D: 91-92 Osmangazi / BURSA</span>
        </div>
      </div>
      <div className={styles.map}>
      <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d10249.933666594317!2d29.051781699158564!3d40.201866103469285!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1str!2str!4v1725900437622!5m2!1str!2str"></iframe>
      </div>
      <div className={styles.copyright}>2024 Tüm hakları saklıdır</div>
    </div>
  )
}

export default Footer