package cn.ztuo.framework;

import java.io.UnsupportedEncodingException;
import java.util.UUID;

import lombok.extern.slf4j.Slf4j;

@Slf4j
public class TokenHelper {
	
	private static final String ACCESS_TOKEN_KEY = "Ronsl^5asdf mxa,7e81d";
	
	private static final String SEP = ":";

	public static String generateToken(Long userId) {
		return generateToken(userId, System.currentTimeMillis());
	}

	public static String generateUUIDToken() {
		return UUID.randomUUID().toString().replaceAll("-", "");
	}

	private static String generateToken(Long userId, long timestamp) {
		return userId + SEP + timestamp + SEP + getDigest(userId, timestamp);
	}

	private static String getDigest(Long userId, long timestamp) {
		String info = userId + SEP + timestamp;
		return MD5.getMD5(getUTF8(info + ACCESS_TOKEN_KEY));
	}

	public static String[] parseToken(String token) {
		return token.split(SEP);
	}

	public boolean isValid(Long userId, Long timestamp, String digest) {
		return digest.equalsIgnoreCase(getDigest(userId, timestamp));
	}

	private static byte[] getUTF8(String data) {
		try {
			return data.getBytes("UTF-8");
		} catch (UnsupportedEncodingException ex) {
			log.error("Exception {----}" ,ex);
			return null;
		}
	}
}
