--
-- PostgreSQL database dump
--

-- Dumped from database version 14.1
-- Dumped by pg_dump version 14.1

-- Started on 2021-12-19 12:14:17

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 242 (class 1255 OID 18351)
-- Name: durumutrueyap(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.durumutrueyap() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
	update islemler set durum = true where siparis_no = new.siparis_no;
	return new;
end;
$$;


ALTER FUNCTION public.durumutrueyap() OWNER TO postgres;

--
-- TOC entry 248 (class 1255 OID 17195)
-- Name: kasapara(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kasapara() RETURNS integer
    LANGUAGE plpgsql
    AS $$
declare 
f integer;
toplam integer;
begin
toplam := 0;
for f in select hesap from hesaplar where durum=true
loop
	toplam := toplam + f;
end loop;
return toplam;
end;
$$;


ALTER FUNCTION public.kasapara() OWNER TO postgres;

--
-- TOC entry 241 (class 1255 OID 18288)
-- Name: kayıtkontrolu(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."kayıtkontrolu"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
IF LENGTH(NEW.password) < 8 OR NEW.password IS NULL THEN
RAISE EXCEPTION 'Password is less than eight (8) characters';
END IF;
IF NEW.username IS NULL THEN
RAISE EXCEPTION 'Username cannot be NULL';
END IF;
RETURN NEW;
END;
$$;


ALTER FUNCTION public."kayıtkontrolu"() OWNER TO postgres;

--
-- TOC entry 243 (class 1255 OID 17020)
-- Name: personelekle(character varying, character varying, character varying, integer, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.personelekle(IN p_tc_no character varying, IN p_ad character varying, IN p_soyad character varying, IN p_gorev_no integer, IN p_maas integer)
    LANGUAGE plpgsql
    AS $$
begin
insert into personeller (tc_no,ad,soyad,gorev_no,maas) values (p_tc_no,p_ad,p_soyad,p_gorev_no,p_maas);
end;
$$;


ALTER PROCEDURE public.personelekle(IN p_tc_no character varying, IN p_ad character varying, IN p_soyad character varying, IN p_gorev_no integer, IN p_maas integer) OWNER TO postgres;

--
-- TOC entry 244 (class 1255 OID 18354)
-- Name: rezervasyonsil(integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.rezervasyonsil(IN p_no integer)
    LANGUAGE plpgsql
    AS $$
begin
	delete from rezervasyonlar where rezervasyon_no = p_no;
	end;
$$;


ALTER PROCEDURE public.rezervasyonsil(IN p_no integer) OWNER TO postgres;

--
-- TOC entry 249 (class 1255 OID 18324)
-- Name: siparissayisiarttir(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.siparissayisiarttir() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
	UPDATE musteriler SET siparis_sayisi = siparis_sayisi + 1 WHERE musteri_no = NEW.musteri_no;
	return new;
END
$$;


ALTER FUNCTION public.siparissayisiarttir() OWNER TO postgres;

--
-- TOC entry 259 (class 1255 OID 18350)
-- Name: toplampersonel(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.toplampersonel() RETURNS TABLE(toplam bigint)
    LANGUAGE plpgsql
    AS $$
    BEGIN
         RETURN QUERY
             SELECT count(*) FROM personeller;
    END;
$$;


ALTER FUNCTION public.toplampersonel() OWNER TO postgres;

--
-- TOC entry 250 (class 1255 OID 18330)
-- Name: urunazalt(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.urunazalt() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
	UPDATE stok set adet = adet-new.adet WHERE urun_no = NEW.urun_no;
	delete from stok where adet = 0; 
	return new;
END
$$;


ALTER FUNCTION public.urunazalt() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 228 (class 1259 OID 17907)
-- Name: admin; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.admin (
    admin_no integer NOT NULL,
    personel_no integer,
    username character varying(40),
    password character varying(40)
);


ALTER TABLE public.admin OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 17906)
-- Name: admin_admin_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.admin_admin_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.admin_admin_no_seq OWNER TO postgres;

--
-- TOC entry 3491 (class 0 OID 0)
-- Dependencies: 227
-- Name: admin_admin_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.admin_admin_no_seq OWNED BY public.admin.admin_no;


--
-- TOC entry 234 (class 1259 OID 18174)
-- Name: admin_hareketleri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.admin_hareketleri (
    hareket_no integer NOT NULL,
    admin_no integer,
    tarih character varying(255)
);


ALTER TABLE public.admin_hareketleri OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 18173)
-- Name: admin_hareketleri_hareket_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.admin_hareketleri_hareket_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.admin_hareketleri_hareket_no_seq OWNER TO postgres;

--
-- TOC entry 3492 (class 0 OID 0)
-- Dependencies: 233
-- Name: admin_hareketleri_hareket_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.admin_hareketleri_hareket_no_seq OWNED BY public.admin_hareketleri.hareket_no;


--
-- TOC entry 238 (class 1259 OID 18236)
-- Name: hesaplar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hesaplar (
    hesap_no integer NOT NULL,
    siparis_no integer,
    odemeturu_no integer,
    indirim integer,
    toplam_tutar integer,
    hesap integer,
    tarih character varying(255),
    durum boolean
);


ALTER TABLE public.hesaplar OWNER TO postgres;

--
-- TOC entry 237 (class 1259 OID 18235)
-- Name: hesaplar_hesap_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hesaplar_hesap_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hesaplar_hesap_no_seq OWNER TO postgres;

--
-- TOC entry 3493 (class 0 OID 0)
-- Dependencies: 237
-- Name: hesaplar_hesap_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hesaplar_hesap_no_seq OWNED BY public.hesaplar.hesap_no;


--
-- TOC entry 240 (class 1259 OID 18253)
-- Name: islemler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.islemler (
    islem_no integer NOT NULL,
    masa_no integer,
    siparis_no integer,
    durum boolean
);


ALTER TABLE public.islemler OWNER TO postgres;

--
-- TOC entry 239 (class 1259 OID 18252)
-- Name: islemler_islem_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.islemler_islem_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.islemler_islem_no_seq OWNER TO postgres;

--
-- TOC entry 3494 (class 0 OID 0)
-- Dependencies: 239
-- Name: islemler_islem_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.islemler_islem_no_seq OWNED BY public.islemler.islem_no;


--
-- TOC entry 216 (class 1259 OID 17080)
-- Name: kategoriler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kategoriler (
    kategori_no integer NOT NULL,
    kategori_ad character varying(40)
);


ALTER TABLE public.kategoriler OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 17079)
-- Name: kategoriler_kategori_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.kategoriler_kategori_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.kategoriler_kategori_no_seq OWNER TO postgres;

--
-- TOC entry 3495 (class 0 OID 0)
-- Dependencies: 215
-- Name: kategoriler_kategori_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kategoriler_kategori_no_seq OWNED BY public.kategoriler.kategori_no;


--
-- TOC entry 226 (class 1259 OID 17580)
-- Name: masalar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.masalar (
    masa_no integer NOT NULL,
    durum boolean
);


ALTER TABLE public.masalar OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 17579)
-- Name: masalar_masa_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.masalar_masa_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.masalar_masa_no_seq OWNER TO postgres;

--
-- TOC entry 3496 (class 0 OID 0)
-- Dependencies: 225
-- Name: masalar_masa_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.masalar_masa_no_seq OWNED BY public.masalar.masa_no;


--
-- TOC entry 212 (class 1259 OID 17045)
-- Name: musteriler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.musteriler (
    musteri_no integer NOT NULL,
    ad character varying(40),
    soyad character varying(40),
    tc_no character varying(11),
    adres character varying(255),
    tel character varying(11),
    siparis_sayisi integer
);


ALTER TABLE public.musteriler OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 17044)
-- Name: musteriler_musteri_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.musteriler_musteri_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.musteriler_musteri_no_seq OWNER TO postgres;

--
-- TOC entry 3497 (class 0 OID 0)
-- Dependencies: 211
-- Name: musteriler_musteri_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.musteriler_musteri_no_seq OWNED BY public.musteriler.musteri_no;


--
-- TOC entry 224 (class 1259 OID 17522)
-- Name: odeme_turleri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.odeme_turleri (
    odemeturu_no integer NOT NULL,
    ad character varying(255)
);


ALTER TABLE public.odeme_turleri OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 17521)
-- Name: odeme_turleri_odemeturu_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.odeme_turleri_odemeturu_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.odeme_turleri_odemeturu_no_seq OWNER TO postgres;

--
-- TOC entry 3498 (class 0 OID 0)
-- Dependencies: 223
-- Name: odeme_turleri_odemeturu_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.odeme_turleri_odemeturu_no_seq OWNED BY public.odeme_turleri.odemeturu_no;


--
-- TOC entry 236 (class 1259 OID 18214)
-- Name: paket_servis; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.paket_servis (
    paket_no integer NOT NULL,
    musteri_no integer,
    personel_no integer,
    siparis_no integer,
    adres character varying(255),
    durum boolean
);


ALTER TABLE public.paket_servis OWNER TO postgres;

--
-- TOC entry 235 (class 1259 OID 18213)
-- Name: paket_servis_paket_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.paket_servis_paket_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.paket_servis_paket_no_seq OWNER TO postgres;

--
-- TOC entry 3499 (class 0 OID 0)
-- Dependencies: 235
-- Name: paket_servis_paket_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.paket_servis_paket_no_seq OWNED BY public.paket_servis.paket_no;


--
-- TOC entry 210 (class 1259 OID 17031)
-- Name: personel_gorevleri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.personel_gorevleri (
    gorev_no integer NOT NULL,
    gorev_ad character varying(40)
);


ALTER TABLE public.personel_gorevleri OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 17030)
-- Name: personel_gorevleri_gorev_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.personel_gorevleri_gorev_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.personel_gorevleri_gorev_no_seq OWNER TO postgres;

--
-- TOC entry 3500 (class 0 OID 0)
-- Dependencies: 209
-- Name: personel_gorevleri_gorev_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.personel_gorevleri_gorev_no_seq OWNED BY public.personel_gorevleri.gorev_no;


--
-- TOC entry 222 (class 1259 OID 17289)
-- Name: personeller; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.personeller (
    personel_no integer NOT NULL,
    tc_no character varying(11),
    ad character varying(40),
    soyad character varying(40),
    gorev_no integer,
    maas integer
);


ALTER TABLE public.personeller OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 17288)
-- Name: personeller_personel_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.personeller_personel_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.personeller_personel_no_seq OWNER TO postgres;

--
-- TOC entry 3501 (class 0 OID 0)
-- Dependencies: 221
-- Name: personeller_personel_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.personeller_personel_no_seq OWNED BY public.personeller.personel_no;


--
-- TOC entry 230 (class 1259 OID 17931)
-- Name: rezervasyonlar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.rezervasyonlar (
    rezervasyon_no integer NOT NULL,
    musteri_no integer,
    masa_no integer,
    tarih character varying(255),
    kisi_sayisi integer
);


ALTER TABLE public.rezervasyonlar OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 17930)
-- Name: rezervasyonlar_rezervasyon_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.rezervasyonlar_rezervasyon_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.rezervasyonlar_rezervasyon_no_seq OWNER TO postgres;

--
-- TOC entry 3502 (class 0 OID 0)
-- Dependencies: 229
-- Name: rezervasyonlar_rezervasyon_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.rezervasyonlar_rezervasyon_no_seq OWNED BY public.rezervasyonlar.rezervasyon_no;


--
-- TOC entry 214 (class 1259 OID 17073)
-- Name: servis_turleri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.servis_turleri (
    servisturu_no integer NOT NULL,
    ad character varying(255)
);


ALTER TABLE public.servis_turleri OWNER TO postgres;

--
-- TOC entry 213 (class 1259 OID 17072)
-- Name: servis_turleri_servisturu_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.servis_turleri_servisturu_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.servis_turleri_servisturu_no_seq OWNER TO postgres;

--
-- TOC entry 3503 (class 0 OID 0)
-- Dependencies: 213
-- Name: servis_turleri_servisturu_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.servis_turleri_servisturu_no_seq OWNED BY public.servis_turleri.servisturu_no;


--
-- TOC entry 232 (class 1259 OID 18142)
-- Name: siparisler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.siparisler (
    siparis_no integer NOT NULL,
    urun_no integer,
    servisturu_no integer,
    adet integer
);


ALTER TABLE public.siparisler OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 18141)
-- Name: siparisler_siparis_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.siparisler_siparis_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.siparisler_siparis_no_seq OWNER TO postgres;

--
-- TOC entry 3504 (class 0 OID 0)
-- Dependencies: 231
-- Name: siparisler_siparis_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.siparisler_siparis_no_seq OWNED BY public.siparisler.siparis_no;


--
-- TOC entry 220 (class 1259 OID 17277)
-- Name: stok; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.stok (
    stok_no integer NOT NULL,
    urun_no integer,
    adet integer
);


ALTER TABLE public.stok OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 17276)
-- Name: stok_stok_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.stok_stok_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.stok_stok_no_seq OWNER TO postgres;

--
-- TOC entry 3505 (class 0 OID 0)
-- Dependencies: 219
-- Name: stok_stok_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.stok_stok_no_seq OWNED BY public.stok.stok_no;


--
-- TOC entry 218 (class 1259 OID 17264)
-- Name: urunler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.urunler (
    urun_no integer NOT NULL,
    urun_ad character varying(40),
    kategori_no integer,
    fiyat integer
);


ALTER TABLE public.urunler OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 17263)
-- Name: urunler_urun_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.urunler_urun_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.urunler_urun_no_seq OWNER TO postgres;

--
-- TOC entry 3506 (class 0 OID 0)
-- Dependencies: 217
-- Name: urunler_urun_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.urunler_urun_no_seq OWNED BY public.urunler.urun_no;


--
-- TOC entry 3256 (class 2604 OID 17910)
-- Name: admin admin_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.admin ALTER COLUMN admin_no SET DEFAULT nextval('public.admin_admin_no_seq'::regclass);


--
-- TOC entry 3259 (class 2604 OID 18177)
-- Name: admin_hareketleri hareket_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.admin_hareketleri ALTER COLUMN hareket_no SET DEFAULT nextval('public.admin_hareketleri_hareket_no_seq'::regclass);


--
-- TOC entry 3261 (class 2604 OID 18239)
-- Name: hesaplar hesap_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hesaplar ALTER COLUMN hesap_no SET DEFAULT nextval('public.hesaplar_hesap_no_seq'::regclass);


--
-- TOC entry 3262 (class 2604 OID 18256)
-- Name: islemler islem_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.islemler ALTER COLUMN islem_no SET DEFAULT nextval('public.islemler_islem_no_seq'::regclass);


--
-- TOC entry 3250 (class 2604 OID 17083)
-- Name: kategoriler kategori_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kategoriler ALTER COLUMN kategori_no SET DEFAULT nextval('public.kategoriler_kategori_no_seq'::regclass);


--
-- TOC entry 3255 (class 2604 OID 17583)
-- Name: masalar masa_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.masalar ALTER COLUMN masa_no SET DEFAULT nextval('public.masalar_masa_no_seq'::regclass);


--
-- TOC entry 3248 (class 2604 OID 17048)
-- Name: musteriler musteri_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.musteriler ALTER COLUMN musteri_no SET DEFAULT nextval('public.musteriler_musteri_no_seq'::regclass);


--
-- TOC entry 3254 (class 2604 OID 17525)
-- Name: odeme_turleri odemeturu_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odeme_turleri ALTER COLUMN odemeturu_no SET DEFAULT nextval('public.odeme_turleri_odemeturu_no_seq'::regclass);


--
-- TOC entry 3260 (class 2604 OID 18217)
-- Name: paket_servis paket_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.paket_servis ALTER COLUMN paket_no SET DEFAULT nextval('public.paket_servis_paket_no_seq'::regclass);


--
-- TOC entry 3247 (class 2604 OID 17034)
-- Name: personel_gorevleri gorev_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personel_gorevleri ALTER COLUMN gorev_no SET DEFAULT nextval('public.personel_gorevleri_gorev_no_seq'::regclass);


--
-- TOC entry 3253 (class 2604 OID 17292)
-- Name: personeller personel_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personeller ALTER COLUMN personel_no SET DEFAULT nextval('public.personeller_personel_no_seq'::regclass);


--
-- TOC entry 3257 (class 2604 OID 17934)
-- Name: rezervasyonlar rezervasyon_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rezervasyonlar ALTER COLUMN rezervasyon_no SET DEFAULT nextval('public.rezervasyonlar_rezervasyon_no_seq'::regclass);


--
-- TOC entry 3249 (class 2604 OID 17076)
-- Name: servis_turleri servisturu_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.servis_turleri ALTER COLUMN servisturu_no SET DEFAULT nextval('public.servis_turleri_servisturu_no_seq'::regclass);


--
-- TOC entry 3258 (class 2604 OID 18145)
-- Name: siparisler siparis_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.siparisler ALTER COLUMN siparis_no SET DEFAULT nextval('public.siparisler_siparis_no_seq'::regclass);


--
-- TOC entry 3252 (class 2604 OID 17280)
-- Name: stok stok_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stok ALTER COLUMN stok_no SET DEFAULT nextval('public.stok_stok_no_seq'::regclass);


--
-- TOC entry 3251 (class 2604 OID 17267)
-- Name: urunler urun_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.urunler ALTER COLUMN urun_no SET DEFAULT nextval('public.urunler_urun_no_seq'::regclass);


--
-- TOC entry 3473 (class 0 OID 17907)
-- Dependencies: 228
-- Data for Name: admin; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.admin (admin_no, personel_no, username, password) VALUES (8, 1, 'alicetin', '12345678');


--
-- TOC entry 3479 (class 0 OID 18174)
-- Dependencies: 234
-- Data for Name: admin_hareketleri; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.admin_hareketleri (hareket_no, admin_no, tarih) VALUES (29, 8, '19.12.2021 08:53:45');
INSERT INTO public.admin_hareketleri (hareket_no, admin_no, tarih) VALUES (30, 8, '19.12.2021 08:55:43');
INSERT INTO public.admin_hareketleri (hareket_no, admin_no, tarih) VALUES (31, 8, '19.12.2021 08:59:53');
INSERT INTO public.admin_hareketleri (hareket_no, admin_no, tarih) VALUES (32, 8, '19.12.2021 09:00:32');


--
-- TOC entry 3483 (class 0 OID 18236)
-- Dependencies: 238
-- Data for Name: hesaplar; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.hesaplar (hesap_no, siparis_no, odemeturu_no, indirim, toplam_tutar, hesap, tarih, durum) VALUES (31, 1, 1, 1, 14, 13, '19.12.2021 08:54:18', true);
INSERT INTO public.hesaplar (hesap_no, siparis_no, odemeturu_no, indirim, toplam_tutar, hesap, tarih, durum) VALUES (32, 2, 1, 0, 21, 21, '19.12.2021 08:55:18', true);


--
-- TOC entry 3485 (class 0 OID 18253)
-- Dependencies: 240
-- Data for Name: islemler; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.islemler (islem_no, masa_no, siparis_no, durum) VALUES (27, 3, 1, true);


--
-- TOC entry 3461 (class 0 OID 17080)
-- Dependencies: 216
-- Data for Name: kategoriler; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.kategoriler (kategori_no, kategori_ad) VALUES (1, 'içecek');
INSERT INTO public.kategoriler (kategori_no, kategori_ad) VALUES (2, 'tatlı');


--
-- TOC entry 3471 (class 0 OID 17580)
-- Dependencies: 226
-- Data for Name: masalar; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.masalar (masa_no, durum) VALUES (6, false);
INSERT INTO public.masalar (masa_no, durum) VALUES (3, false);
INSERT INTO public.masalar (masa_no, durum) VALUES (4, false);
INSERT INTO public.masalar (masa_no, durum) VALUES (8, false);
INSERT INTO public.masalar (masa_no, durum) VALUES (7, false);
INSERT INTO public.masalar (masa_no, durum) VALUES (1, false);
INSERT INTO public.masalar (masa_no, durum) VALUES (5, false);


--
-- TOC entry 3457 (class 0 OID 17045)
-- Dependencies: 212
-- Data for Name: musteriler; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.musteriler (musteri_no, ad, soyad, tc_no, adres, tel, siparis_sayisi) VALUES (1, 'aslı', 'bahar', '98765432105', 'karşıyaka mah no:41', '05487541669', 2);


--
-- TOC entry 3469 (class 0 OID 17522)
-- Dependencies: 224
-- Data for Name: odeme_turleri; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.odeme_turleri (odemeturu_no, ad) VALUES (1, 'kredi kartı');
INSERT INTO public.odeme_turleri (odemeturu_no, ad) VALUES (2, 'nakit');


--
-- TOC entry 3481 (class 0 OID 18214)
-- Dependencies: 236
-- Data for Name: paket_servis; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.paket_servis (paket_no, musteri_no, personel_no, siparis_no, adres, durum) VALUES (16, 1, 1, 2, 'konyaaltı no:15', true);


--
-- TOC entry 3455 (class 0 OID 17031)
-- Dependencies: 210
-- Data for Name: personel_gorevleri; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.personel_gorevleri (gorev_no, gorev_ad) VALUES (3, 'aşçı');
INSERT INTO public.personel_gorevleri (gorev_no, gorev_ad) VALUES (4, 'garson');
INSERT INTO public.personel_gorevleri (gorev_no, gorev_ad) VALUES (1, 'kurye');
INSERT INTO public.personel_gorevleri (gorev_no, gorev_ad) VALUES (2, 'komi');


--
-- TOC entry 3467 (class 0 OID 17289)
-- Dependencies: 222
-- Data for Name: personeller; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.personeller (personel_no, tc_no, ad, soyad, gorev_no, maas) VALUES (3, '98765432101', 'Filiz', 'Bahar', 2, 4500);
INSERT INTO public.personeller (personel_no, tc_no, ad, soyad, gorev_no, maas) VALUES (4, '12345678902', 'Fatih', 'Deniz', 3, 5200);
INSERT INTO public.personeller (personel_no, tc_no, ad, soyad, gorev_no, maas) VALUES (8, '12345678904', 'melih', 'ekimler', 2, 4600);
INSERT INTO public.personeller (personel_no, tc_no, ad, soyad, gorev_no, maas) VALUES (1, '12345678901', 'Ali', 'Çetin', 1, 5500);


--
-- TOC entry 3475 (class 0 OID 17931)
-- Dependencies: 230
-- Data for Name: rezervasyonlar; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.rezervasyonlar (rezervasyon_no, musteri_no, masa_no, tarih, kisi_sayisi) VALUES (5, 1, 5, '23-12-2021', 4);


--
-- TOC entry 3459 (class 0 OID 17073)
-- Dependencies: 214
-- Data for Name: servis_turleri; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.servis_turleri (servisturu_no, ad) VALUES (1, 'self');
INSERT INTO public.servis_turleri (servisturu_no, ad) VALUES (2, 'paket');


--
-- TOC entry 3477 (class 0 OID 18142)
-- Dependencies: 232
-- Data for Name: siparisler; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.siparisler (siparis_no, urun_no, servisturu_no, adet) VALUES (1, 2, 1, 2);
INSERT INTO public.siparisler (siparis_no, urun_no, servisturu_no, adet) VALUES (2, 2, 1, 3);


--
-- TOC entry 3465 (class 0 OID 17277)
-- Dependencies: 220
-- Data for Name: stok; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.stok (stok_no, urun_no, adet) VALUES (8, 2, 15);


--
-- TOC entry 3463 (class 0 OID 17264)
-- Dependencies: 218
-- Data for Name: urunler; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.urunler (urun_no, urun_ad, kategori_no, fiyat) VALUES (2, 'soda', 1, 7);
INSERT INTO public.urunler (urun_no, urun_ad, kategori_no, fiyat) VALUES (1, 'puding', 2, 11);


--
-- TOC entry 3507 (class 0 OID 0)
-- Dependencies: 227
-- Name: admin_admin_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.admin_admin_no_seq', 12, true);


--
-- TOC entry 3508 (class 0 OID 0)
-- Dependencies: 233
-- Name: admin_hareketleri_hareket_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.admin_hareketleri_hareket_no_seq', 32, true);


--
-- TOC entry 3509 (class 0 OID 0)
-- Dependencies: 237
-- Name: hesaplar_hesap_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hesaplar_hesap_no_seq', 32, true);


--
-- TOC entry 3510 (class 0 OID 0)
-- Dependencies: 239
-- Name: islemler_islem_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.islemler_islem_no_seq', 27, true);


--
-- TOC entry 3511 (class 0 OID 0)
-- Dependencies: 215
-- Name: kategoriler_kategori_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kategoriler_kategori_no_seq', 4, true);


--
-- TOC entry 3512 (class 0 OID 0)
-- Dependencies: 225
-- Name: masalar_masa_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.masalar_masa_no_seq', 7, true);


--
-- TOC entry 3513 (class 0 OID 0)
-- Dependencies: 211
-- Name: musteriler_musteri_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.musteriler_musteri_no_seq', 3, true);


--
-- TOC entry 3514 (class 0 OID 0)
-- Dependencies: 223
-- Name: odeme_turleri_odemeturu_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.odeme_turleri_odemeturu_no_seq', 3, true);


--
-- TOC entry 3515 (class 0 OID 0)
-- Dependencies: 235
-- Name: paket_servis_paket_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.paket_servis_paket_no_seq', 16, true);


--
-- TOC entry 3516 (class 0 OID 0)
-- Dependencies: 209
-- Name: personel_gorevleri_gorev_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.personel_gorevleri_gorev_no_seq', 4, true);


--
-- TOC entry 3517 (class 0 OID 0)
-- Dependencies: 221
-- Name: personeller_personel_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.personeller_personel_no_seq', 9, true);


--
-- TOC entry 3518 (class 0 OID 0)
-- Dependencies: 229
-- Name: rezervasyonlar_rezervasyon_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.rezervasyonlar_rezervasyon_no_seq', 5, true);


--
-- TOC entry 3519 (class 0 OID 0)
-- Dependencies: 213
-- Name: servis_turleri_servisturu_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.servis_turleri_servisturu_no_seq', 3, true);


--
-- TOC entry 3520 (class 0 OID 0)
-- Dependencies: 231
-- Name: siparisler_siparis_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.siparisler_siparis_no_seq', 2, true);


--
-- TOC entry 3521 (class 0 OID 0)
-- Dependencies: 219
-- Name: stok_stok_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.stok_stok_no_seq', 8, true);


--
-- TOC entry 3522 (class 0 OID 0)
-- Dependencies: 217
-- Name: urunler_urun_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.urunler_urun_no_seq', 3, true);


--
-- TOC entry 3288 (class 2606 OID 18179)
-- Name: admin_hareketleri admin_hareketleri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.admin_hareketleri
    ADD CONSTRAINT admin_hareketleri_pkey PRIMARY KEY (hareket_no);


--
-- TOC entry 3282 (class 2606 OID 17912)
-- Name: admin admin_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.admin
    ADD CONSTRAINT admin_pkey PRIMARY KEY (admin_no);


--
-- TOC entry 3292 (class 2606 OID 18241)
-- Name: hesaplar hesaplar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hesaplar
    ADD CONSTRAINT hesaplar_pkey PRIMARY KEY (hesap_no);


--
-- TOC entry 3294 (class 2606 OID 18258)
-- Name: islemler islemler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.islemler
    ADD CONSTRAINT islemler_pkey PRIMARY KEY (islem_no);


--
-- TOC entry 3270 (class 2606 OID 17085)
-- Name: kategoriler kategoriler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kategoriler
    ADD CONSTRAINT kategoriler_pkey PRIMARY KEY (kategori_no);


--
-- TOC entry 3280 (class 2606 OID 17585)
-- Name: masalar masalar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.masalar
    ADD CONSTRAINT masalar_pkey PRIMARY KEY (masa_no);


--
-- TOC entry 3266 (class 2606 OID 17050)
-- Name: musteriler musteriler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.musteriler
    ADD CONSTRAINT musteriler_pkey PRIMARY KEY (musteri_no);


--
-- TOC entry 3278 (class 2606 OID 17527)
-- Name: odeme_turleri odeme_turleri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odeme_turleri
    ADD CONSTRAINT odeme_turleri_pkey PRIMARY KEY (odemeturu_no);


--
-- TOC entry 3290 (class 2606 OID 18219)
-- Name: paket_servis paket_servis_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.paket_servis
    ADD CONSTRAINT paket_servis_pkey PRIMARY KEY (paket_no);


--
-- TOC entry 3264 (class 2606 OID 17036)
-- Name: personel_gorevleri personel_gorevleri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personel_gorevleri
    ADD CONSTRAINT personel_gorevleri_pkey PRIMARY KEY (gorev_no);


--
-- TOC entry 3276 (class 2606 OID 17294)
-- Name: personeller personeller_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personeller
    ADD CONSTRAINT personeller_pkey PRIMARY KEY (personel_no);


--
-- TOC entry 3284 (class 2606 OID 17936)
-- Name: rezervasyonlar rezervasyonlar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rezervasyonlar
    ADD CONSTRAINT rezervasyonlar_pkey PRIMARY KEY (rezervasyon_no);


--
-- TOC entry 3268 (class 2606 OID 17078)
-- Name: servis_turleri servis_turleri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.servis_turleri
    ADD CONSTRAINT servis_turleri_pkey PRIMARY KEY (servisturu_no);


--
-- TOC entry 3286 (class 2606 OID 18147)
-- Name: siparisler siparisler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.siparisler
    ADD CONSTRAINT siparisler_pkey PRIMARY KEY (siparis_no);


--
-- TOC entry 3274 (class 2606 OID 17282)
-- Name: stok stok_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stok
    ADD CONSTRAINT stok_pkey PRIMARY KEY (stok_no);


--
-- TOC entry 3272 (class 2606 OID 17269)
-- Name: urunler urunler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.urunler
    ADD CONSTRAINT urunler_pkey PRIMARY KEY (urun_no);


--
-- TOC entry 3314 (class 2620 OID 18352)
-- Name: hesaplar durumu_true_yap; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER durumu_true_yap AFTER UPDATE ON public.hesaplar FOR EACH ROW EXECUTE FUNCTION public.durumutrueyap();


--
-- TOC entry 3311 (class 2620 OID 18289)
-- Name: admin kayıt_kontrolu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "kayıt_kontrolu" BEFORE INSERT OR UPDATE ON public.admin FOR EACH ROW EXECUTE FUNCTION public."kayıtkontrolu"();


--
-- TOC entry 3313 (class 2620 OID 18325)
-- Name: paket_servis siparis_sayisi_arttir; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER siparis_sayisi_arttir AFTER INSERT ON public.paket_servis FOR EACH ROW EXECUTE FUNCTION public.siparissayisiarttir();


--
-- TOC entry 3312 (class 2620 OID 18331)
-- Name: siparisler urun_azalt; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER urun_azalt AFTER INSERT ON public.siparisler FOR EACH ROW EXECUTE FUNCTION public.urunazalt();


--
-- TOC entry 3303 (class 2606 OID 18180)
-- Name: admin_hareketleri fk_admin; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.admin_hareketleri
    ADD CONSTRAINT fk_admin FOREIGN KEY (admin_no) REFERENCES public.admin(admin_no);


--
-- TOC entry 3297 (class 2606 OID 17295)
-- Name: personeller fk_gorev; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personeller
    ADD CONSTRAINT fk_gorev FOREIGN KEY (gorev_no) REFERENCES public.personel_gorevleri(gorev_no);


--
-- TOC entry 3295 (class 2606 OID 17270)
-- Name: urunler fk_kategori; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.urunler
    ADD CONSTRAINT fk_kategori FOREIGN KEY (kategori_no) REFERENCES public.kategoriler(kategori_no);


--
-- TOC entry 3300 (class 2606 OID 17942)
-- Name: rezervasyonlar fk_masa; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rezervasyonlar
    ADD CONSTRAINT fk_masa FOREIGN KEY (masa_no) REFERENCES public.masalar(masa_no);


--
-- TOC entry 3310 (class 2606 OID 18264)
-- Name: islemler fk_masa; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.islemler
    ADD CONSTRAINT fk_masa FOREIGN KEY (masa_no) REFERENCES public.masalar(masa_no);


--
-- TOC entry 3299 (class 2606 OID 17937)
-- Name: rezervasyonlar fk_musteri; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rezervasyonlar
    ADD CONSTRAINT fk_musteri FOREIGN KEY (musteri_no) REFERENCES public.musteriler(musteri_no);


--
-- TOC entry 3305 (class 2606 OID 18225)
-- Name: paket_servis fk_musteri; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.paket_servis
    ADD CONSTRAINT fk_musteri FOREIGN KEY (musteri_no) REFERENCES public.musteriler(musteri_no);


--
-- TOC entry 3308 (class 2606 OID 18247)
-- Name: hesaplar fk_odemeturu; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hesaplar
    ADD CONSTRAINT fk_odemeturu FOREIGN KEY (odemeturu_no) REFERENCES public.odeme_turleri(odemeturu_no);


--
-- TOC entry 3298 (class 2606 OID 17913)
-- Name: admin fk_personel; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.admin
    ADD CONSTRAINT fk_personel FOREIGN KEY (personel_no) REFERENCES public.personeller(personel_no);


--
-- TOC entry 3304 (class 2606 OID 18220)
-- Name: paket_servis fk_personel; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.paket_servis
    ADD CONSTRAINT fk_personel FOREIGN KEY (personel_no) REFERENCES public.personeller(personel_no);


--
-- TOC entry 3302 (class 2606 OID 18153)
-- Name: siparisler fk_servis; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.siparisler
    ADD CONSTRAINT fk_servis FOREIGN KEY (servisturu_no) REFERENCES public.servis_turleri(servisturu_no);


--
-- TOC entry 3306 (class 2606 OID 18230)
-- Name: paket_servis fk_siparis; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.paket_servis
    ADD CONSTRAINT fk_siparis FOREIGN KEY (siparis_no) REFERENCES public.siparisler(siparis_no);


--
-- TOC entry 3307 (class 2606 OID 18242)
-- Name: hesaplar fk_siparis; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hesaplar
    ADD CONSTRAINT fk_siparis FOREIGN KEY (siparis_no) REFERENCES public.siparisler(siparis_no);


--
-- TOC entry 3309 (class 2606 OID 18259)
-- Name: islemler fk_siparis; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.islemler
    ADD CONSTRAINT fk_siparis FOREIGN KEY (siparis_no) REFERENCES public.siparisler(siparis_no);


--
-- TOC entry 3296 (class 2606 OID 17283)
-- Name: stok fk_urun; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stok
    ADD CONSTRAINT fk_urun FOREIGN KEY (urun_no) REFERENCES public.urunler(urun_no);


--
-- TOC entry 3301 (class 2606 OID 18148)
-- Name: siparisler fk_urun; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.siparisler
    ADD CONSTRAINT fk_urun FOREIGN KEY (urun_no) REFERENCES public.urunler(urun_no);


-- Completed on 2021-12-19 12:14:18

--
-- PostgreSQL database dump complete
--

