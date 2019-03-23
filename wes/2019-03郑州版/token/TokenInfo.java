package cn.ztuo.framework;

import lombok.Data;

@Data
public class TokenInfo {

	//短token
	private String authToken;

	//长token
	private String accessToken;

	//token有效时间
	private int expiresIn;

	//用户信息
	private String userAcct;

	//用户ID
	private String userId;

	//版本
	private String version;

	//生效日期
	private String expiresStartDate;

	//渠道编码
	private String chnCode;
}
