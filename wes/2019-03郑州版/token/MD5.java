
package cn.ztuo.framework;

import java.io.IOException;
import java.io.InputStream;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

import org.apache.tomcat.util.codec.binary.Base64;

/**
 * @ClassName: MD5
 * @Description: 一级平台MD5相关工具
 * @author daishuyang
 * @date 2017年12月5日下午3:09:43
 */
public class MD5 {

	public static String getMD5(byte[] source) {
		String s = null;
		try {
			MessageDigest e = MessageDigest.getInstance("MD5");
			e.update(source);
			byte[] tmp = e.digest();
			s = Base64.encodeBase64String(tmp);
		} catch (Exception var4) {
			var4.printStackTrace();
		}
		return s;
	}

	public static String getMD5(String source, String charset) {
		String s = null;
		try {
			MessageDigest e = MessageDigest.getInstance("MD5");
			e.update(source.getBytes(charset));
			byte[] tmp = e.digest();
			s = byteArrayToHexString(tmp);
		} catch (Exception var5) {
			var5.printStackTrace();
		}
		return s;
	}

	public static String getMD5(InputStream in) {
		Object s = null;
		try {
			MessageDigest e = MessageDigest.getInstance("MD5");
			byte[] bytes = new byte[8192];
			int byteCount;
			while ((byteCount = in.read(bytes)) > 0) {
				e.update(bytes, 0, byteCount);
			}
			byte[] digest = e.digest();
			return byteArrayToHexString(digest);
		} catch (NoSuchAlgorithmException var6) {
			var6.printStackTrace();
		} catch (IOException var7) {
			var7.printStackTrace();
		} catch (Exception var8) {
			var8.printStackTrace();
		}
		return (String) s;
	}

	private static String byteArrayToHexString(byte[] bytes) {
		StringBuilder s = new StringBuilder();
		byte[] var2 = bytes;
		int var3 = bytes.length;
		for (int var4 = 0; var4 < var3; ++var4) {
			byte b = var2[var4];
			int h = b >> 4 & 15;
			if (h > 9) {
				s.append((char) (h - 10 + 97));
			} else {
				s.append((char) (h + 48));
			}
			h = b & 15;
			if (h > 9) {
				s.append((char) (h - 10 + 97));
			} else {
				s.append((char) (h + 48));
			}
		}
		return s.toString();
	}
}
