public class ApuProgram
{
	public void L0300_Start()
	{
		D = 0;
		A = 0x00;
		Y = 0xDF;
		[0x15] = YA;
		A = 0x00;
		Y = 0x00;
	}

	public void L030B_Loop()
	{
		[[0x15] +Y] = A;
		Y++;

		if (Z == 0)
			return this.L0312_Skip();

		[0x16]++;
	}

	public void L0312_Skip()
	{
		C = 1; temp = [0x16] - 0xFF;

		if (Z == 0)
			return this.L030B_Loop();

		return this.L0400_ClearRam();
	}

	public void L0400_ClearRam()
	{
		D = 0;
		X = 0xCF;
		S = X;
		A = 0x00;
		X = A;
	}

	public void L0407_Loop()
	{
		[X++] = A;

		if (Z == 0)
			return this.L0407_Loop();

		X = A;
	}

	public void L040D_Loop()
	{
		[0x0300 + X] = A;
		[0x0200 + X] = A;
		[0x0100 + X] = A;
		X++;

		if (Z == 0)
			return this.L040D_Loop();

		A++;
		this.L0B0A();
		[0x34] |= 0x20;

		// DspKeyOff = 0xFF;
		A = 0xFF;
		Y = 0x5C;
		this.L05F2_WriteDspRegister();

		// DspVolumeLeft = 0x60;
		A = 0x60;
		Y = 0x0C;
		this.L05F2_WriteDspRegister();

		// DspVolumeRight = 0x60;
		Y = 0x1C;
		this.L05F2_WriteDspRegister();

		// DspSourceDirectory = 0x1B;  (0x1B00)
		A = 0x1B;
		Y = 0x5D;
		this.L05F2_WriteDspRegister();

		// Timer 0 = 0; (Disabled)
		A = 0xB0;
		[0x00F1] = A;

		// Timer 0 = 500 ticks per second;
		A = 0x10;
		[0x00FA] = A;
		[0x3E] = A;

		// Timer 0 = 1; (Active)
		A = 0x81;
		[0x00F1] = A;
	}

	public void L044A_MainLoop()
	{
		// Y = 10;
		Y = 0x0A;
	}

	public void L044C_Loop()
	{
		C = 1; temp = Y - 0x05;

		// if(Y == 5)
		if (Z == 1)
			return this.L0457_Skip();

		// if(Y > 5)
		if (C == 1)
			return this.L045A_Skip();

		// if(Y < 5)
		C = 1; temp = [0x39] - [0x38];

		if (Z == 0)
			return this.L0468_Skip();
	}

	public void L0457_Skip()
	{
		if (([0x38] & 0x80) != 0)
			return this.L0468_Skip();
	}

	public void L045A_Skip()
	{
		// DspRegister = Table04BA[Y];
		A = [0x04BA + Y];
		[0x00F2] = A;

		// DspValue = [Table04C4[Y]];
		A = [0x04C4 + Y];
		X = A;
		A = [X];
		[0x00F3] = A;
	}

	public void L0468_Skip()
	{
		Y--; if (Z == 0)
			return this.L044C_Loop();

		// Word30 = 0;
		[0x30] = Y;
		[0x31] = Y;

		// Random19 = Random(Random19);
		A = [0x19];
		A ^= [0x1A];
		A >>= 1;
		A >>= 1;
		C = !C;
		Cpu.ROR([0x19]);
		Cpu.ROR([0x1A]);
	}

	public void L0479_WaitForTimer()
	{
		Y = [0x00FD];

		if (Z == 1)
			return this.L0479_WaitForTimer();

		Stack.Push(Y);
		A = 0x20;
		YA = Y * A;
		C = 0;
		A += [0x1C] + C;
		[0x1C] = A;

		if (C == 0)
			return this.L0493_Skip();

		this.L0E98();
		C = 1; temp = [0x39] - [0x38];

		if (Z == 1)
			return this.L0493_Skip();

		[0x38]++;
	}

	public void L0493_Skip()
	{
		Y = Stack.Pop();
		A = [0x3E];
		YA = Y * A;
		C = 0;
		A += [0x3C] + C;
		[0x3C] = A;

		if (C == 0)
			return this.L04A3_Skip();

		this.L06AB_HandleEvents();
	}

	public void L04A1_Done()
	{
		return this.L044A_MainLoop();
	}

	public void L04A3_Skip()
	{
		A = [0x0E];

		if (Z == 1)
			return this.L04A1_Done();

		// ChannelOffset = 0;
		X = 0x00;
		// Value32_ChannelMask = 1;
		[0x32] = 0x01;
	}

	public void L04AC_Loop()
	{
		A = [0x21 + X];

		if (Z == 1)
			return this.L04B3_Skip();

		this.L0DBA_UpdateChannel();
	}

	public void L04B3_Skip()
	{
		// ChannelOffset += 2;
		X++;
		X++;

		// Value32_ChannelMask <<= 1;
		[0x32] <<= 1;

		if (Z == 0)
			return this.L04AC_Loop();

		return this.L04A1_Done();
	}

	public byte[] L04BA_DspRegisterTable = new byte[]
	{
		0xE6,	// Unused
		0x2C,	// Echo Volume Left
		0x3C,	// Echo Volume Right
		0x0D,	// Echo Feedback
		0x4D,	// Echo Enable
		0x6C,	// Flags (Mute, Echo, Reset, Noise)
		0x4C,	// Key On
		0x5C,	// Key Off
		0x3D,	// Noise Enable
		0x2D,	// Pitch Modulation
		0x5C	// Key Off
	}

	public byte[] L04C4_DspValueAddressTable = new byte[]
	{
		0x5C,	// Unused
		0x4C,	// Echo Volume Left
		0x4E,	// Echo Volume Right
		0x3A,	// Echo Feedback
		0x36,	// Echo Enable
		0x34,	// Flags (Mute, Echo, Reset, Noise)
		0x30,	// Key On
		0x0F,	// Key Off
		0x35,	// Noise Enable
		0x37,	// Pitch Modulation
		0x31	// Key Off
	}

	public void L04CF_Done()
	{
		return;
	}

	public void L04D0()
	{
		//if (Y < 0xCA) PlayNote;
		C = 1; temp = Y - 0xCA;

		if (C == 0)
			return this.L0506_PlayNote();

		if (([0xE9] & 0x01) == 0)
			return this.L04DE_Skip();

		this.L0922_LoadInstrument();

		Y = 0xA4;

		return this.L0506_PlayNote();
	}

	public void L04DE_Skip()
	{
		[0x11] = Y;
		A = [0x00A4 + Y];
		[0x12] = A;
		A &= 0x40;

		if (Z == 1)
			return this.L04EE_Skip();

		this.L0A80_HandleEventF1();

		return this.L04F1_Skip();
	}

	public void L04EE_Skip()
	{
		this.L0A90_HandleEventF2();
	}

	public void L04F1_Skip()
	{
		A = [0x12];
		A &= 0xBF;

		this.L0922_LoadInstrument();

		Y = [0x11];
		A = [0x00BC + Y];

		if (N == 1)
			return this.L0502();

		this.L0982_HandleEventD7();
	}

	public void L0502()
	{
		A = [0x00B0 + Y];
		Y = A;
	}

	public void L0506_PlayNote()
	{
		//if (Y >= 0xC8) Skip;
		C = 1; temp = Y - 0xC8;

		if (C == 1)
			return this.L04CF_Done();

		// A = Value1B & Value32_CurrentChannelMask
		A = [0x1B];
		A &= [0x32];

		if (Z == 0)
			return this.L04CF_Done();

		A = Y;
		A &= 0x7F;
		C = 0;
		A += [0x3B] + C;
		C = 0;
		A += [0x0341 + X] + C;
		[0x02B1 + X] = A;
		A = [0x02D1 + X];
		[0x02B0 + X] = A;
		A = [0x0311 + X];
		A >>= 1;
		A = 0x00;
		Cpu.ROR(A);
		[0x0300 + X] = A;
		A = 0x00;
		[0x96 + X] = A;
		[0x0067 + X] = A;
		[0x0330 + X] = A;
		[0xA6 + X] = A;

		// Value49 |= Value32_CurrentChannelMask;
		[0x49] |= [0x32];

		// Value30 |= Value32_CurrentChannelMask;
		[0x30] |= [0x32];

		A = [0x02E0 + X];
		[0x86 + X] = A;

		if (Z == 1)
			return this.L0564_Skip();

		A = [0x02E1 + X];
		[0x87 + X] = A;
		A = [0x02F0 + X];

		if (Z == 0)
			return this.L055A_Skip();

		A = [0x02B1 + X];
		C = 1;
		A -= [0x02F1 + X] + !C;
		[0x02B1 + X] = A;
	}

	public void L055A_Skip()
	{
		A = [0x02F1 + X];
		C = 0;
		A += [0x02B1 + X] + C;
		this.L0B73();
	}

	public void L0564_Skip()
	{
		this.L0B8B_ReadTable2B0();
	}

	public void L0567()
	{
		Y = 0x00;
		A = [0x12];
		C = 1;
		A -= 0x34 + !C;

		if (C == 1)
			return this.L0579_Skip();

		A = [0x12];
		C = 1;
		A -= 0x13 + !C;

		if (C == 1)
			return this.L057D_Skip();

		Y--;
		A <<= 1;
	}

	public void L0579_Skip()
	{
		YA += [0x11] + C;
		[0x11] = YA;
	}

	public void L057D_Skip()
	{
		Stack.Push(X);
		A = [0x12];
		A <<= 1;
		Y = 0x00;
		X = 0x18;
		A = YA / X; Y = YA % X;
		X = A;
		A = [0x05FA + Y];
		[0x16] = A;
		A = [0x05F9 + Y];
		[0x15] = A;
		A = [0x05FC + Y];
		Stack.Push(A);
		A = [0x05FB + Y];
		Y = Stack.Pop();
		YA -= [0x15];
		Y = [0x11];
		YA = Y * A;
		A = Y;
		Y = 0x00;
		YA += [0x15] + C;
		[0x16] = Y;
		A <<= 1;
		Cpu.ROL([0x16]);
		[0x15] = A;
		return this.L05B0_Skip();
	}

	public void L05AC_Loop()
	{
		[0x16] <<= 1;
		Cpu.ROR(A);
		X++;
	}

	public void L05B0_Skip()
	{
		C = 1; temp = X - 0x06;

		if (Z == 0)
			return this.L05AC_Loop();

		[0x15] = A;
		X = Stack.Pop();
		A = [0x0220 + X];
		Y = [0x16];
		YA = Y * A;
		[0x17] = YA;
		A = [0x0220 + X];
		Y = [0x15];
		YA = Y * A;
		Stack.Push(Y);
		A = [0x0221 + X];
		Y = [0x15];
		YA = Y * A;
		YA += [0x17] + C;
		[0x17] = YA;
		A = [0x0221 + X];
		Y = [0x16];
		YA = Y * A;
		Y = A;
		A = Stack.Pop();
		YA += [0x17] + C;
		[0x17] = YA;
		A = X;
		A = (A >> 4) | (A << 4);
		A >>= 1;
		A |= 0x02;
		Y = A;
		A = [0x17];
		this.L05EA_WriteDspRegister();
		Y++;
		A = [0x18];
	}

	public void L05EA_WriteDspRegister()
	{
		Stack.Push(A);

		// A = Value32_CurrentChannelMask & Value1B;
		A = [0x32];
		A &= [0x1B];

		A = Stack.Pop();

		if (Z == 0)
			return this.L05F8_Done();
	}

	public void L05F2_WriteDspRegister()
	{
		// DSP
		[0x00F2] = Y;
		[0x00F3] = A;
	}

	public void L05F8_Done()
	{
		return;
	}

	public void L0613_HandleParameters()
	{
		Y = [0xE9];

		if (N == 1)
			return this.L062F_Skip();

		// Table0201_ChannelDurations[X] = Table0E80_Durations[A >> 4];
		Stack.Push(A);
		A = (A >> 4) | (A << 4);
		A &= 0x07;
		Y = A;
		A = [0x0E80 + Y];
		[0x0201 + X] = A;

		// Table0210_ChannelVelocities[X] = Table0E88_Velocities[A & 0x0F];
		A = Stack.Pop();
		A &= 0x0F;
		Y = A;
		A = [0x0E88 + Y];
		[0x0210 + X] = A;
		return this.L0722_Loop();
	}

	public void L062F_Skip()
	{
		// if (A >= 0x40) Skip;
		C = 1; temp = A - 0x40;

		if (C == 1)
			return this.L063F_Skip();

		// Set Channel Duration (High Resolution)
		A &= 0x3F;
		Y = A;
		A = [0xFF00 + Y];
		[0x0201 + X] = A;
		return this.L0743();
	}

	public void L063F_Skip()
	{
		// Set Channel Velocity (High Resolution)
		A &= 0x3F;
		Y = A;
		A = [0xFF00 + Y];
		[0x0210 + X] = A;
		return this.L0722_Loop();
	}

	/// <summary>
	/// Reads two bytes from Pointer1D, and stores value in YA.
	/// </summary>
	public void L064B_ReadPointer1D()
	{
		// A = [Pointer1D++];
		Y = 0x00;
		A = [[0x1D] + Y];
		[0x1D]++;   // 16-bit

		Stack.Push(A);

		A = [[0x1D] + Y];
		[0x1D]++;   // 16-bit
		Y = A;

		A = Stack.Pop();
		return;
	}

	public void L0659_Done()
	{
		A <<= 1;

		if (Z == 1)
			return this.L0669();

		// Pointer1D = Table18E2[X];
		X = A;
		A = [0x18E3 + X];
		Y = A;
		A = [0x18E2 + X];
		[0x1D] = YA;

		[0x0C] = 0x02;
	}

	public void L0669()
	{
		A = [0x1B];
		A ^= 0xFF;
		temp = A - [0x0031];[0x0031] |= A;
		return;
	}

	public void L0671_ClearChannels()
	{
		X = 0x0E;

		//Value32_CurrentChannelMask = 0x80; (Channel 8)
		[0x32] = 0x80;
	}

	public void L0676_Loop()
	{
		A = 0xFF;
		[0x0251 + X] = A;
		A = 0x0A;
		this.L0982_HandleEventD7();

		// A = 0;
		[0x0211 + X] = A;
		[0x02D1 + X] = A;
		[0x0341 + X] = A;
		[0x02E0 + X] = A;
		[0x97 + X] = A;
		[0xA7 + X] = A;
		[0xBA + X] = A;
		X--;
		X--;
		[0x32] <<= 1;

		if (Z == 0)
			return this.L0676_Loop();

		[0x45] = A;
		[0x53] = A;
		[0x3F] = A;
		[0x3B] = A;
		[0x1F] = A;
		[0x4A] = A;
		[0x44] = 0xC0;
		[0x3E] = 0x20;
	}

	public void L06AA_Done()
	{
		return;
	}

	public void L06AB_HandleEvents()
	{
		Y = [0x08];
		A = [0x0E];
		[0x08] = A;
		C = 1; temp = Y - [0x0E];

		if (Z == 0)
			return this.L0659_Done();

		A = [0x0E];

		if (Z == 1)
			return this.L06AA_Done();

		A = [0x0C];

		if (Z == 1)
			return this.L0711_Skip();

		[0x000C]--; if (Z == 0)
			return this.L0671_ClearChannels();
	}

	public void L06C0_Loop()
	{
		this.L064B_ReadPointer1D();

		if (Z == 0)
			return this.L06E1_Skip();

		Y = A;

		if (Z == 0)
			return this.L06D0_Skip();

		[0x0E] = A;
		[0x08] = A;
		[0xB9] = A;

		return this.L0659_Done();
	}

	public void L06D0_Skip()
	{
		[0x1F]--;

		if (N == 0)
			return this.L06D6_Skip();

		[0x1F] = A;
	}

	public void L06D6_Skip()
	{
		this.L064B_ReadPointer1D();
		X = [0x1F];

		if (Z == 1)
			return this.L06C0_Loop();

		[0x1D] = YA;
		return this.L06C0_Loop();
	}

	public void L06E1_Skip()
	{
		// Pointer17 = YA;
		[0x17] = YA;

		Y = 0x0F;
	}

	public void L06E5_Loop()
	{
		// Table20_ChannelPointers[Y] = [Pointer17][Y];
		A = [[0x17] + Y];
		[0x0020 + Y] = A;
		Y--;

		if (N == 0)
			return this.L06E5_Loop();

		X = 0x00;
		[0x32] = 0x01;
	}

	public void L06F2_Loop()
	{
		A = [0x21 + X];

		if (Z == 1)
			return this.L0700_Skip();

		A = [0x0211 + X];

		if (Z == 0)
			return this.L0700_Skip();

		A = 0x00;
		this.L0922_LoadInstrument();
	}

	public void L0700_Skip()
	{
		// Reset Variables
		A = 0x00;
		[0x66 + X] = A;
		[0x76 + X] = A;
		[0x77 + X] = A;
		A++;
		[0x56 + X] = A;
		X++;
		X++;
		[0x32] <<= 1;

		if (Z == 0)
			return this.L06F2_Loop();
	}

	public void L0711_Skip()
	{
		X = 0x00;
		[0x49] = X;
		[0x32] = 0x01;
	}

	public void L0718_Loop()
	{
		[0x33] = X;
		A = [0x21 + X];

		if (Z == 1)
			return this.L077A_Skip();

		[0x56 + X]--;

		if (Z == 0)
			return this.L0774_Skip();
	}

	public void L0722_Loop()
	{
		this.L0857_ReadChannel();

		// if (A != 0) skip;
		if (Z == 0)
			return this.L073E_Skip();

		// Handle End Of Channel
		A = [0x66 + X];

		if (Z == 1)
			return this.L06C0_Loop();

		this.L0A75_RestoreChannelPointer();
		[0x66 + X]--;

		if (Z == 0)
			return this.L0722_Loop();

		// Update Channel Addresses
		A = [0x0230 + X];
		[0x20 + X] = A;
		A = [0x0231 + X];
		[0x21 + X] = A;
		return this.L0722_Loop();
	}

	public void L073E_Skip()
	{
		// if (A >= 0x80) PlayNote();
		if (N == 1)
			return this.L074B_PlayNote();

		// Store Length
		[0x0200 + X] = A;
	}

	public void L0743()
	{
		this.L0857_ReadChannel();

		// if (A >= 0x80) PlayNote();
		if (N == 1)
			return this.L074B_PlayNote();

		return this.L0613_HandleParameters();
	}

	public void L074B_PlayNote()
	{
		C = 1; temp = A - 0xD6;

		if (C == 0)
			return this.L0754_Skip();

		this.L0845_HandleEvent();
		return this.L0722_Loop();
	}

	public void L0754_Skip()
	{
		this.L04D0();
		A = [0x0200 + X];
		[0x56 + X] = A;
		Y = A;
		Stack.Push(Y);
		A = [0x0201 + X];
		YA = Y * A;
		A = Y;

		if (Z == 0)
			return this.L0766_Skip();

		A++;
	}

	public void L0766_Skip()
	{
		[0x57 + X] = A;
		Y = Stack.Pop();
		A = [0xBA + X];
		YA = Y * A;
		A = Y;

		if (Z == 0)
			return this.L0770_Skip();

		A++;
	}

	public void L0770_Skip()
	{
		[0xBB + X] = A;
		return this.L0777_Skip();
	}

	public void L0774_Skip()
	{
		this.L0CB0();
	}

	public void L0777_Skip()
	{
		this.L0B53();
	}

	public void L077A_Skip()
	{
		X++;
		X++;
		[0x32] <<= 1;

		if (Z == 0)
			return this.L0718_Loop();

		A = [0x3F];

		if (Z == 1)
			return this.L078F();

		YA = [0x41];
		YA += [0x3D] + C;

		[0x003F]--; if (Z == 0)
			return this.L078D();

		YA = [0x3F];
	}

	public void L078D()
	{
		[0x3D] = YA;
	}

	public void L078F()
	{
		A = [0x53];

		if (Z == 1)
			return this.L07A8();

		YA = [0x4F];
		YA += [0x4B] + C;
		[0x4B] = YA;
		YA = [0x51];
		YA += [0x4D] + C;

		[0x0053]--; if (Z == 0)
			return this.L07A6();

		YA = [0x53];
		[0x4B] = YA;
		Y = [0x55];
	}

	public void L07A6()
	{
		[0x4D] = YA;
	}

	public void L07A8()
	{
		A = [0x45];

		if (Z == 1)
			return this.L07BA();

		YA = [0x47];
		YA += [0x43] + C;

		[0x0045]--; if (Z == 0)
			return this.L07B5();

		YA = [0x45];
	}

	public void L07B5()
	{
		[0x43] = YA;
		[0x49] = 0xFF;
	}

	public void L07BA()
	{
		X = 0x00;
		[0x32] = 0x01;
	}

	public void L07BF_Loop()
	{
		A = [0x21 + X];

		if (Z == 1)
			return this.L07C6();

		this.L0BD1();
	}

	public void L07C6()
	{
		X++;
		X++;
		[0x32] <<= 1;

		if (Z == 0)
			return this.L07BF_Loop();

		return;
	}

	public byte[] L07CD_EventHandlers = new byte[]
	{
		0x22, 0x09,		// D6: L0922_LoadInstrument
		0x82, 0x09,		// D7: L0982_HandleEventD7
		0x90, 0x09,		// D8: L0990_HandleEventD8
		0xA9, 0x09,		// D9: L09A9_HandleEventD9
		0xB5, 0x09,		// DA: L09B5_HandleEventDA
		0xD0, 0x09,		// DB: L09D0_SetWord43
		0xD5, 0x09,		// DC: L09D5_SetWord45
		0xEC, 0x09,		// DD: L09EC_SetTempo
		0xF1, 0x09,		// DE: L09F1_SetWord3F
		0x03, 0x0A,		// DF: L0A03_SetValue3B
		0x06, 0x0A,		// E0: L0A06_SetTable341
		0x0A, 0x0A,		// E1: L0A0A_SetTable340
		0x16, 0x0A,		// E2: L0A16_ClearTableA7
		0x37, 0x0A,		// E3: L0A37_SetTable250
		0x40, 0x0A,		// E4: L0A40_SetTable76
		0x5D, 0x0A,		// E5: L0A5D_HandleCall
		0xC0, 0x09,		// E6: L09C0_HandleEventE6
		0x19, 0x0A,		// E7: L0A19_SetTable02E0
		0x1D, 0x0A,		// E8: L0A1D_SetTable02E0
		0x33, 0x0A,		// E9: L0A33_SetTable02E0
		0x59, 0x0A,		// EA: L0A59_SetTable02D1
		0xA2, 0x0A,		// EB: L0AA2_SetValue11
		0xE1, 0x0A,		// EC: L0AE1_SetWord4B
		0xE8, 0x0A,		// ED: L0AE8_SetValue39
		0xC0, 0x0A,		// EE: L0AC0_SetValue53
		0x63, 0x0B,		// EF: L0B63_SetTable86
		0x50, 0x0B,		// F0: L0B50_SetPercussionBase
		0x80, 0x0A,		// F1: L0A80_HandleEventF1
		0x90, 0x0A,		// F2: L0A90_HandleEventF2
		0x96, 0x0B,		// F3: L0B96_HandleEventF3
		0x9C, 0x0B,		// F4: L0B9C_HandleEventF4
		0x8C, 0x08,		// F5: L088C_SetValue016COrFlagE9
		0xAD, 0x08,		// F6: L08AD_SetValue016D
		0xA2, 0x0B,		// F7: L0BA2_SkipBytes
		0xAB, 0x0B,		// F8: L0BAB_SkipBytes
		0x78, 0x08,		// F9: L0878_LoadTable016E
		0x63, 0x08,		// FA: L0863_LoadInstruments
		0xE2, 0x08,		// FB: L08E2_LoadInstrument
		0xB1, 0x08,		// FC: L08B1_WriteDspRegister
		0xC9, 0x08,		// FD: L08C9_WriteDspRegister
	}

	public byte[] L081D_EventLengths = new byte[]
	{
		0x01,			// D6
		0x01,			// D7
		0x02,			// D8
		0x03,			// D9
		0x00,			// DA
		0x01,			// DB
		0x02,			// DC
		0x01,			// DD
		0x02,			// DE
		0x01,			// DF
		0x01,			// E0
		0x03,			// E1
		0x00,			// E2
		0x01,			// E3
		0x02,			// E4
		0x03,			// E5
		0x01,			// E6
		0x03,			// E7
		0x03,			// E8
		0x00,			// E9
		0x01,			// EA
		0x03,			// EB
		0x00,			// EC
		0x03,			// ED
		0x03,			// EE
		0x03,			// EF
		0x01,			// F0
		0x00,			// F1
		0x00,			// F2
		0x00,			// F3
		0x00,			// F4
		0x01,			// F5
		0x01,			// F6
		0x01,			// F7
		0x01,			// F8
		0x00,			// F9			(Actually loads 24 bytes)
		0x01,			// FA			(Actually skips additional N * 4 bytes)
		0x01,			// FB
		0x02,			// FC
		0x02			// FD
	}

	public void L0845_HandleEvent()
	{
		// Stack.Push(Table0721_EventHandlerAddresses[((A * 2) & 0xFF)]);
		A <<= 1;
		Y = A;
		A = [0x0722 + Y];
		Stack.Push(A);
		A = [0x0721 + Y];
		Stack.Push(A);

		// A = Table07C7_EventLengths[A & 0x7F];
		A = Y;
		A >>= 1;
		Y = A;
		A = [0x07C7 + Y];

		// if (A == 0) CallEventHandler;  (No parameters)
		if (Z == 1)
			return this.L085D_Done();
	}

	/// <summary>
	/// Reads one byte from channel X, and stores value in A and Y.
	/// </summary>
	public void L0857_ReadChannel()
	{
		A = [0x20 + X];
	}

	/// <summary>
	///  Skips one byte on channel X.
	/// </summary>
	public void L0859_SkipChannel()
	{
		[0x20 + X]++;

		if (Z == 1)
			return this.L085F_Skip();
	}

	public void L085D_Done()
	{
		Y = A;
		return;
	}

	public void L085F_Skip()
	{
		[0x21 + X]++;
		Y = A;
		return;
	}

	public void L0863_LoadInstruments()
	{
		A = [0x20 + X];
		[0xB6] = A;
		A = [0x21 + X];
		[0xB7] = A;
		A = 0x04;
		YA = Y * A;
	}

	public void L086E_SkipBytes()
	{
		C = 0;
		A += [0x20 + X] + C;
		[0x20 + X] = A;

		if (C == 0)
			return this.L0877_Done();

		[0x21 + X]++;
	}

	public void L0877_Done()
	{
		return;
	}

	public void L0878_LoadTable016E()
	{
		Y = [0x21 + X];
		A = [0x20 + X];
		[0x11] = YA;
		Y = 0x23;
	}

	public void L0880_Loop()
	{
		A = [[0x11] + Y];
		[0x016E + Y] = A;
		Y--;

		if (N == 0)
			return this.L0880_Loop();

		A = 0x24;
		return this.L086E_SkipBytes();
	}

	public void L088C_SetValue016COrFlagE9()
	{
		C = 1; temp = Y - 0xF0;

		if (C == 0)
			return this.L08A9_Skip();

		[0x11] &= ~0x01;
		A = (A >> 4) | (A << 4);

		if (N == 1)
			return this.L0897_Skip();

		[0x11] |= 0x01;
	}

	public void L0897_Skip()
	{
		A = (A >> 4) | (A << 4);
		A &= 0x07;
		Y = A;
		A = [0x10FF + Y];

		if (([0x11] & 0x01) == 0)
			return this.L08A5_Skip();

		temp = A - [0x00E9]; [0x00E9] |= A;
		return;
	}

	public void L08A5_Skip()
	{
		temp = A - [0x00E9]; [0x00E9] &= ~A;
		return;
	}

	public void L08A9_Skip()
	{
		[0x016C] = Y;
		return;
	}

	public void L08AD_SetValue016D()
	{
		[0x016D] = Y;
		return;
	}

	public void L08B1_WriteDspRegister()
	{
		[0x0351 + X] = A;
		A = X;
		A = (A >> 4) | (A << 4);
		A >>= 1;
		A |= 0x05;
		Y = A;
		A = [0x0351 + X];
		this.L05EA_WriteDspRegister();
		Stack.Push(Y);
		this.L0857_ReadChannel();
		Y = Stack.Pop();
		Y++;
		return this.L05EA_WriteDspRegister();
	}

	public void L08C9_WriteDspRegister()
	{
		[0xBA + X] = A;
		A = X;
		A = (A >> 4) | (A << 4);
		A >>= 1;
		A |= 0x07;
		Stack.Push(A);
		this.L0857_ReadChannel();
		[0x0350 + X] = A;
		Y = Stack.Pop();
		return this.L05EA_WriteDspRegister();
	}

	public void L08E2_LoadInstrument()
	{
		// Y = A * 4;
		A <<= 1;
		A <<= 1;
		Y = A;

		// Push(TablePointerB6[Y]);
		A = [[0xB6] + Y];
		Y++;
		Stack.Push(A);

		// Table0251[X] = TablePointerB6[Y + 1];
		A = [[0xB6] + Y];
		Y++;
		[0x0251 + X] = A;

		// Table02A1[X] = TablePointerB6[Y + 2];
		A = [[0xB6] + Y];
		Y++;
		[0x02A1 + X] = A;

		// Table0281[X] = TablePointerB6[Y + 2] & 0x1F;
		A &= 0x1F;
		[0x0281 + X] = A;

		// Table0280[X] = 0;
		A = 0x00;
		[0x0280 + X] = A;

		// Table0250[X] = 0;
		[0x0250 + X] = A;

		// TableBA[X] = 0;
		[0xBA + X] = A;

		// Value11 = TablePointerB6[Y + 3];
		A = [[0xB6] + Y];
		[0x11] = A;

		// if (TablePointerB6[Y + 3] & 0x0F == 0) Skip;
		A &= 0x0F;

		if (Z == 1)
			return this.L0913_Skip();

		// Table02D1[X] = ((TablePointerB6[Y + 3] & 0x0F) - 1) * 5;
		A--;
		Y = 0x05;
		YA = Y * A;
		[0x02D1 + X] = A;
	}

	public void L0913_Skip()
	{
		//if (TablePointerB6[Y + 3] & 0x70 == 0) Skip;
		A = [0x11];
		A &= 0x70;

		if (Z == 1)
			return this.L0921_Skip();

		// Table0341[X] = Table08DA[TablePointerB6[Y + 3] >> 4];
		A = (A >> 4) | (A << 4);
		Y = A;
		A = [0x08DA + Y];
		[0x0341 + X] = A;
	}

	public void L0921_Skip()
	{
		// Restore Instrument Value1
		A = Stack.Pop();
	}

	public void L0922_LoadInstrument()
	{
		[0x0211 + X] = A;
		Y = A;

		if (N == 0)
			return this.L092E_Skip();

		// Drum Sample
		C = 1;
		A -= 0xCA + !C;
		C = 0;
		A += [0x4A] + C;
	}

	public void L092E_Skip()
	{
		// Pointer15 = L1980_InstrumentData + (A * 6);
		Y = 0x06;
		YA = Y * A;
		[0x15] = YA;
		C = 0;
		[0x15] += 0x80;
		[0x16] += 0x19;

		A = [0x1B];
		A &= [0x32];

		if (Z == 0)
			return this.L0981_Done();

		// Set Channel Sample
		Stack.Push(X);
		A = X;
		A = (A >> 4) | (A << 4);
		A >>= 1;
		A |= 0x04;
		X = A;
		Y = 0x00;
		A = [[0x15] + Y];

		if (N == 0)
			return this.L095B_Skip();

		A &= 0x1F;
		[0x34] &= 0x20;
		temp = A - [0x0034]; [0x0034] |= A;
		[0x35] |= [0x32];
		A = Y;
		return this.L0962_Skip();
	}

	public void L095B_Skip()
	{
		A = [0x32];
		temp = A - [0x0035]; [0x0035] &= ~A;
	}

	public void L0960_Loop()
	{
		A = [[0x15] + Y];
	}

	public void L0962_Skip()
	{
		// DSP
		[0x00F2] = X;
		[0x00F3] = A;
		X++;
		Y++;
		C = 1; temp = Y - 0x04;

		if (Z == 0)
			return this.L0960_Loop();

		X = Stack.Pop();
		A = [[0x15] + Y];
		[0x0221 + X] = A;
		Y++;
		A = [[0x15] + Y];
		[0x0220 + X] = A;
		Y = 0x01;
		A = [[0x15] + Y];
		[0x0351 + X] = A;
	}

	public void L0981_Done()
	{
		return;
	}

	public void L0982_HandleEventD7()
	{
		[0x02A1 + X] = A;
		A &= 0x1F;
		[0x0281 + X] = A;
		A = 0x00;
		[0x0280 + X] = A;
		return;
	}

	public void L0990_HandleEventD8()
	{
		[0x77 + X] = A;
		Stack.Push(A);
		this.L0857_ReadChannel();
		[0x02A0 + X] = A;
		C = 1;
		A -= [0x0281 + X] + !C;
		X = Stack.Pop();
		this.L0BB5();
		[0x0290 + X] = A;
		A = Y;
		[0x0291 + X] = A;
		return;
	}

	public void L09A9_HandleEventD9()
	{
		[0x0310 + X] = A;
		this.L0857_ReadChannel();
		[0x0301 + X] = A;
		this.L0857_ReadChannel();
	}

	public void L09B5_HandleEventDA()
	{
		[0x97 + X] = A;
		[0x0321 + X] = A;
		A = 0x00;
		[0x0311 + X] = A;
		return;
	}

	public void L09C0_HandleEventE6()
	{
		[0x0311 + X] = A;
		Stack.Push(A);
		Y = 0x00;
		A = [0x97 + X];
		X = Stack.Pop();
		A = YA / X; Y = YA % X;
		X = [0x33];
		[0x0320 + X] = A;
		return;
	}

	public void L09D0_SetWord43()
	{
		A = 0x00;
		[0x43] = YA;
		return;
	}

	public void L09D5_SetWord45()
	{
		Y = [0x016A];

		if (Z == 0)
			return this.L09EB();

		[0x45] = A;
		this.L0857_ReadChannel();
		[0x46] = A;
		C = 1;
		A -= [0x44] + !C;
		X = [0x45];
		this.L0BB5();
		[0x47] = YA;
	}

	public void L09EB()
	{
		return;
	}

	public void L09EC_SetTempo()
	{
		A = 0x00;
		[0x3D] = YA;
		return;
	}

	public void L09F1_SetWord3F()
	{
		[0x3F] = A;
		this.L0857_ReadChannel();
		[0x40] = A;
		C = 1;
		A -= [0x3E] + !C;
		X = [0x3F];
		this.L0BB5();
		[0x41] = YA;
		return;
	}

	public void L0A03_SetValue3B()
	{
		[0x3B] = A;
		return;
	}

	public void L0A06_SetTable341()
	{
		[0x0341 + X] = A;
		return;
	}

	public void L0A0A_SetTable340()
	{
		[0x0340 + X] = A;
		this.L0857_ReadChannel();
		[0x0331 + X] = A;
		this.L0857_ReadChannel();
	}

	public void L0A16_ClearTableA7()
	{
		[0xA7 + X] = A;
		return;
	}

	public void L0A19_SetTable02E0()
	{
		A = 0x01;
		return this.L0A1F();
	}

	public void L0A1D_SetTable02E0()
	{
		A = 0x00;
	}

	public void L0A1F()
	{
		[0x02F0 + X] = A;
		A = Y;
		[0x02E1 + X] = A;
		this.L0857_ReadChannel();
		[0x02E0 + X] = A;
		this.L0857_ReadChannel();
		[0x02F1 + X] = A;
		return;
	}

	public void L0A33_SetTable02E0()
	{
		[0x02E0 + X] = A;
		return;
	}

	public void L0A37_SetTable250()
	{
		[0x0251 + X] = A;
		A = 0x00;
		[0x0250 + X] = A;
		return;
	}

	public void L0A40_SetTable76()
	{
		[0x76 + X] = A;
		Stack.Push(A);
		this.L0857_ReadChannel();
		[0x0270 + X] = A;
		C = 1;
		A -= [0x0251 + X] + !C;
		X = Stack.Pop();
		this.L0BB5();
		[0x0260 + X] = A;
		A = Y;
		[0x0261 + X] = A;
		return;
	}

	public void L0A59_SetTable02D1()
	{
		[0x02D1 + X] = A;
		return;
	}

	public void L0A5D_HandleCall()
	{
		[0x0240 + X] = A;
		this.L0857_ReadChannel();
		[0x0241 + X] = A;
		this.L0857_ReadChannel();
		[0x66 + X] = A;
		A = [0x20 + X];
		[0x0230 + X] = A;
		A = [0x21 + X];
		[0x0231 + X] = A;
	}

	public void L0A75_RestoreChannelPointer()
	{
		A = [0x0240 + X];
		[0x20 + X] = A;
		A = [0x0241 + X];
		[0x21 + X] = A;
		return;
	}

	public void L0A80_HandleEventF1()
	{
		A = [0x1B];
		A &= [0x32];

		if (Z == 1)
			return this.L0A8C();

		A = [0x32];
		temp = A - [0x0192];[0x0192] |= A;
		return;
	}

	public void L0A8C()
	{
		[0x36] |= [0x32];
		return;
	}

	public void L0A90_HandleEventF2()
	{
		A = [0x1B];
		A &= [0x32];

		if (Z == 1)
			return this.L0A9C();

		A = [0x32];
		temp = A - [0x0192]; [0x0192] &= ~A;
		return;
	}

	public void L0A9C()
	{
		A = [0x32];
		temp = A - [0x0036]; [0x0036] &= ~A;
		return;
	}

	public void L0AA2_SetValue11()
	{
		[0x11] = A;
		[0x0192] = A;
		A = [0x1B];
		A ^= 0xFF;
		A &= [0x11];
		[0x36] = A;
		this.L0857_ReadChannel();
		A = 0x00;
		[0x4B] = YA;
		this.L0857_ReadChannel();
		A = 0x00;
		[0x4D] = YA;
		[0x34] &= ~0x20;
		return;
	}

	public void L0AC0_SetValue53()
	{
		[0x53] = A;
		this.L0857_ReadChannel();
		[0x54] = A;
		C = 1;
		A -= [0x4C] + !C;
		X = [0x53];
		this.L0BB5();
		[0x4F] = YA;
		this.L0857_ReadChannel();
		[0x55] = A;
		C = 1;
		A -= [0x4E] + !C;
		X = [0x53];
		this.L0BB5();
		[0x51] = YA;
		return;
	}

	public void L0AE1_SetWord4B()
	{
		[0x4B] = YA;
		[0x4D] = YA;
		[0x34] |= 0x20;
		return;
	}

	public void L0AE8_SetValue39()
	{
		this.L0B0A();
		this.L0857_ReadChannel();
		[0x3A] = A;
		this.L0857_ReadChannel();
		Y = 0x08;
		YA = Y * A;
		X = A;
		Y = 0x0F;
	}

	public void L0AF9_Loop()
	{
		A = [0x0E60 + X];
		this.L05F2_WriteDspRegister();
		X++;
		A = Y;
		C = 0;
		A += 0x10 + C;
		Y = A;

		if (N == 0)
			return this.L0AF9_Loop();

		X = [0x33];
		return;
	}

	public void L0B0A()
	{
		[0x39] = A;

		// A = DspEchoDelay
		Y = 0x7D;
		[0x00F2] = Y;
		A = [0x00F3];
		C = 1; temp = A - [0x39];

		if (Z == 1)
			return this.L0B43_Skip();

		A &= 0x0F;
		A ^= 0xFF;

		if (([0x38] & 0x80) == 0)
			return this.L0B22_Skip();

		C = 0;
		A += [0x38] + C;
	}

	public void L0B22_Skip()
	{
		[0x38] = A;
		Y = 0x04;
	}

	public void L0B26_Loop()
	{
		// DSP
		A = [0x04BA + Y];
		[0x00F2] = A;
		A = 0x00;
		[0x00F3] = A;

		Y--; if (Z == 0)
			return this.L0B26_Loop();

		A = [0x34];
		A |= 0x20;
		Y = 0x6C;
		this.L05F2_WriteDspRegister();
		A = [0x39];
		Y = 0x7D;
		this.L05F2_WriteDspRegister();
	}

	public void L0B43_Skip()
	{
		A <<= 1;
		A <<= 1;
		A <<= 1;
		A ^= 0xFF;
		C = 1;
		A += 0xFF + C;
		Y = 0x6D;
		return this.L05F2_WriteDspRegister();
	}

	public void L0B50_SetPercussionBase()
	{
		[0x4A] = A;
		return;
	}

	public void L0B53()
	{
		A = [0x86 + X];

		if (Z == 0)
			return this.L0B8A_Done();

		A = [0x20 + X];
		C = 1; temp = A - 0xEF;

		if (Z == 0)
			return this.L0B8A_Done();

		this.L0859_SkipChannel();
		this.L0857_ReadChannel();
	}

	public void L0B63_SetTable86()
	{
		[0x87 + X] = A;
		this.L0857_ReadChannel();
		[0x86 + X] = A;
		this.L0857_ReadChannel();
		C = 0;
		A += [0x3B] + C;
		A += [0x0341 + X] + C;
	}

	public void L0B73()
	{
		A &= 0x7F;
		[0x02D0 + X] = A;
		C = 1;
		A -= [0x02B1 + X] + !C;
		Y = [0x86 + X];
		Stack.Push(Y);
		X = Stack.Pop();
		this.L0BB5();
		[0x02C0 + X] = A;
		A = Y;
		[0x02C1 + X] = A;
	}

	public void L0B8A_Done()
	{
		return;
	}

	public void L0B8B_ReadTable2B0()
	{
		A = [0x02B1 + X];
		[0x12] = A;
		A = [0x02B0 + X];
		[0x11] = A;
		return;
	}

	public void L0B96_HandleEventF3()
	{
		A = [0x32];
		temp = A - [0x00B8]; [0x00B8] |= A;
		return;
	}

	public void L0B9C_HandleEventF4()
	{
		A = [0x32];
		temp = A - [0x00B8]; [0x00B8] &= ~A;
		return;
	}

	public void L0BA2_SkipBytes()
	{
		Stack.Push(A);
		A = [0xB9];
		A &= [0x32];
		A = Stack.Pop();

		if (Z == 1)
			return this.L0BAB();

		return;
	}

	public void L0BAB_SkipBytes()
	{
		C = 0;
		A += [0x20 + X] + C;
		[0x20 + X] = A;

		if (C == 0)
			return this.L0BB4();

		[0x21 + X]++;
	}

	public void L0BB4()
	{
		return;
	}

	public void L0BB5()
	{
		C = !C;
		Cpu.ROR([0x13]);

		if (N == 0)
			return this.L0BBD();

		A ^= 0xFF;
		A++;
	}

	public void L0BBD()
	{
		Y = 0x00;
		A = YA / X; Y = YA % X;
		Stack.Push(A);
		A = 0x00;
		A = YA / X; Y = YA % X;
		Y = Stack.Pop();
		X = [0x33];
	}

	public void L0BC7()
	{
		if (([0x13] & 0x80) == 0)
			return this.L0BD0_Done();

		[0x15] = YA;
		YA = [0x0F];
		YA -= [0x15];
	}

	public void L0BD0_Done()
	{
		return;
	}

	public void L0BD1()
	{
		A = [0x76 + X];

		if (Z == 1)
			return this.L0BDE();

		A = 0x50;
		Y = 0x02;
		[0x76 + X]--;
		this.L0C8C();
	}

	public void L0BDE()
	{
		Y = [0xA7 + X];

		if (Z == 1)
			return this.L0C05();

		A = [0x0340 + X];

		C = 1; temp = A - [0xA6 + X]; if (Z == 0)
			return this.L0C03();

		[0x4932] |= [0x00]; 0x4932;
		A = [0x0330 + X];

		if (N == 0)
			return this.L0BF7();

		Y++;

		if (Z == 0)
			return this.L0BF7();

		A = 0x80;
		return this.L0BFB();
	}

	public void L0BF7()
	{
		C = 0;
		A += [0x0331 + X] + C;
	}

	public void L0BFB()
	{
		[0x0330 + X] = A;
		this.L0E40();
		return this.L0C0A();
	}

	public void L0C03()
	{
		[0xA6 + X]++;
	}

	public void L0C05()
	{
		A = 0xFF;
		this.L0E4B();
	}

	public void L0C0A()
	{
		A = [0x77 + X];

		if (Z == 1)
			return this.L0C17();

		A = 0x80;
		Y = 0x02;
		[0x77 + X]--;
		this.L0C8C();
	}

	public void L0C17()
	{
		A = [0x32];
		A &= [0x49];

		if (Z == 1)
			return this.L0C76_Done();

		A = [0x0281 + X];
		Y = A;
		A = [0x0280 + X];
		[0x11] = YA;
		A = [0x32];
		A &= [0x1B];

		if (Z == 0)
			return this.L0C76_Done();

	}

	public void L0C2C()
	{
		A = [0x0361];
		A &= 0x02;

		if (Z == 1)
			return this.L0C39();

		[0x12] = 0x0A;
		[0x11] = 0x00;
	}

	public void L0C39()
	{
		A = X;
		A = (A >> 4) | (A << 4);
		A >>= 1;
		[0x13] = A;
	}

	public void L0C3E()
	{
		Y = [0x12];
		A = [0x0C78 + Y];
		C = 1;
		A -= [0x0C77 + Y] + !C;
		Y = [0x11];
		YA = Y * A;
		A = Y;
		Y = [0x12];
		C = 0;
		A += [0x0C77 + Y] + C;
		Y = A;
		A = [0x0271 + X];
		YA = Y * A;
		A = [0x02A1 + X];
		A <<= 1;

		if (([0x13] & 0x01) == 0)
			return this.L0C5E();

		A <<= 1;
	}

	public void L0C5E()
	{
		A = Y;

		if (C == 0)
			return this.L0C64();

		A ^= 0xFF;
		A++;
	}

	public void L0C64()
	{
		Y = [0x13];
		this.L05EA_WriteDspRegister();
		Y = 0x14;
		A = 0x00;
		YA -= [0x11];
		[0x11] = YA;
		[0x13]++;

		if (([0x13] & 0x02) == 0)
			return this.L0C3E();
	}

	public void L0C76_Done()
	{
		return;
	}

	public void L0C8C()
	{
		[0x4932] |= [0x00]; 0x4932;
	}

	public void L0C8F()
	{
		[0x15] = YA;
		[0x17] = YA;
		Stack.Push(X);
		Y = Stack.Pop();
		C = 0;

		if (Z == 0)
			return this.L0CA2_Skip();

		[0x17] += 0x1F;
		A = 0x00;
		[[0x15] + Y] = A;
		Y++;
		return this.L0CAB();
	}

	public void L0CA2_Skip()
	{
		[0x17] += 0x10;
		this.L0CA9();
		Y++;
	}

	public void L0CA9()
	{
		A = [[0x15] + Y];
	}

	public void L0CAB()
	{
		A += [[0x17] + Y] +C;
		[[0x15] + Y] = A;
		return;
	}

	public void L0CB0()
	{
		A = [0x57 + X];

		if (Z == 0)
			return this.L0CB7_Skip();

		return this.L0D46_Skip();
	}

	public void L0CB7_Skip()
	{
		[0x57 + X]--;

		if (Z == 1)
			return this.L0CD6_Skip();

		A = [0xBA + X];

		if (Z == 1)
			return this.L0CD1_Skip();

		[0xBB + X]--;

		if (Z == 0)
			return this.L0CD1_Skip();

		A = X;
		A = (A >> 4) | (A << 4);
		A >>= 1;
		A |= 0x05;
		Y = A;
		A = [0x0351 + X];
		A &= 0x7F;
		this.L05EA_WriteDspRegister();
	}

	public void L0CD1_Skip()
	{
		A = 0x02;

		temp = A - [0x56 + X]; if (Z == 0)
			return this.L0D46_Skip();
	}

	public void L0CD6_Skip()
	{
		A = [0x66 + X];
		[0x18] = A;
		A = [0x20 + X];
		Y = [0x21 + X];
	}

	public void L0CDE_Loop()
	{
		[0x15] = YA;
		Y = 0x00;
	}

	public void L0CE2_Loop()
	{
		A = [[0x15] + Y];

		if (Z == 1)
			return this.L0D02_Skip();

		if (N == 1)
			return this.L0CED_Skip();
	}

	public void L0CE8_Loop()
	{
		Y++;
		A = [[0x15] + Y];

		if (N == 0)
			return this.L0CE8_Loop();
	}

	public void L0CED_Skip()
	{
		C = 1; temp = A - 0xC8;

		if (Z == 1)
			return this.L0D46_Skip();

		C = 1; temp = A - 0xE5;

		if (Z == 1)
			return this.L0D1E();

		C = 1; temp = A - 0xD6;

		if (C == 0)
			return this.L0D29_Skip();

		Stack.Push(Y);
		Y = A;
		A = Stack.Pop();
		A += [0x0747 + Y] + C;
		Y = A;
		return this.L0CE2_Loop();
	}

	public void L0D02_Skip()
	{
		A = [0x18];

		if (Z == 1)
			return this.L0D29_Skip();

		[0x18]--;

		if (Z == 0)
			return this.L0D14_Skip();

		A = [0x0231 + X];
		Stack.Push(A);
		A = [0x0230 + X];
		Y = Stack.Pop();
		return this.L0CDE_Loop();
	}

	public void L0D14_Skip()
	{
		A = [0x0241 + X];
		Stack.Push(A);
		A = [0x0240 + X];
		Y = Stack.Pop();
		return this.L0CDE_Loop();
	}

	public void L0D1E()
	{
		Y++;
		A = [[0x15] + Y];
		Stack.Push(A);
		Y++;
		A = [[0x15] + Y];
		Y = A;
		A = Stack.Pop();
		return this.L0CDE_Loop();
	}

	public void L0D29_Skip()
	{
		A = [0xB8];
		A &= [0x32];

		if (Z == 0)
			return this.L0D46_Skip();

		A = [0x32];
		Y = 0x5C;
		this.L05EA_WriteDspRegister();
		A = [0xBA + X];

		if (Z == 1)
			return this.L0D46_Skip();

		A = X;
		A = (A >> 4) | (A << 4);
		A >>= 1;
		A |= 0x05;
		Y = A;
		A = [0x0351 + X];
		this.L05EA_WriteDspRegister();
	}

	public void L0D46_Skip()
	{
		[0x14] &= ~0x80;
		A = [0x86 + X];

		if (Z == 1)
			return this.L0D5F_Skip();

		A = [0x87 + X];

		if (Z == 1)
			return this.L0D54_Skip();

		[0x87 + X]--;
		return this.L0D5F_Skip();
	}

	public void L0D54_Skip()
	{
		[0x14] |= 0x80;
		A = 0xB0;
		Y = 0x02;
		[0x86 + X]--;
		this.L0C8F();
	}

	public void L0D5F_Skip()
	{
		this.L0B8B_ReadTable2B0();
		A = [0x97 + X];

		if (Z == 1)
			return this.L0DB6_Done();

		A = [0x32];
		A &= [0x1B];

		if (Z == 0)
			return this.L0DB6_Done();

		A = [0x0310 + X];

		C = 1; temp = A - [0x96 + X]; if (Z == 0)
			return this.L0DB4();

		A = [0x0067 + X];
		C = 1; temp = A - [0x0311 + X];

		if (Z == 0)
			return this.L0D7F_Skip();

		A = [0x0321 + X];
		return this.L0D8A_Skip();
	}

	public void L0D7F_Skip()
	{
		[0x67 + X]++;
		Y = A;

		if (Z == 1)
			return this.L0D86_Skip();

		A = [0x97 + X];
	}

	public void L0D86_Skip()
	{
		C = 0;
		A += [0x0320 + X] + C;
	}

	public void L0D8A_Skip()
	{
		[0x97 + X] = A;
		A = [0x0300 + X];
		C = 0;
		A += [0x0301 + X] + C;
		[0x0300 + X] = A;
	}

	public void L0D96_Loop()
	{
		[0x13] = A;
		A <<= 1;
		A <<= 1;

		if (C == 0)
			return this.L0D9E_Skip();

		A ^= 0xFF;
	}

	public void L0D9E_Skip()
	{
		Y = A;
		A = [0x97 + X];
		C = 1; temp = A - 0xF1;

		if (C == 0)
			return this.L0DAA_Skip();

		A &= 0x0F;
		YA = Y * A;
		return this.L0DAE_Skip();
	}

	public void L0DAA_Skip()
	{
		YA = Y * A;
		A = Y;
		Y = 0x00;
	}

	public void L0DAE_Skip()
	{
		this.L0E2B();
	}

	public void L0DB1_Done()
	{
		return this.L0567();
	}

	public void L0DB4()
	{
		[0x96 + X]++;
	}

	public void L0DB6_Done()
	{
		if (([0x14] & 0x80) != 0)
			return this.L0DB1_Done();

		return;
	}

	public void L0DBA_UpdateChannel()
	{
		[0x14] &= ~0x80;
		A = [0xA7 + X];

		if (Z == 1)
			return this.L0DC9();

		A = [0x0340 + X];

		C = 1; temp = A - [0xA6 + X]; if (Z == 0)
			return this.L0DC9();

		this.L0E33();
	}

	public void L0DC9()
	{
		A = [0x0281 + X];
		Y = A;
		A = [0x0280 + X];
		[0x11] = YA;
		A = [0x77 + X];

		if (Z == 1)
			return this.L0DE0();

		A = [0x0291 + X];
		Y = A;
		A = [0x0290 + X];
		this.L0E15();
	}

	public void L0DE0()
	{

		if (([0x14] & 0x80) == 0)
			return this.L0DE6();

		this.L0C2C();
	}

	public void L0DE6()
	{
		[0x14] &= ~0x80;
		this.L0B8B_ReadTable2B0();
		A = [0x86 + X];

		if (Z == 1)
			return this.L0DFD();

		A = [0x87 + X];

		if (Z == 0)
			return this.L0DFD();

		A = [0x02C1 + X];
		Y = A;
		A = [0x02C0 + X];
		this.L0E15();
	}

	public void L0DFD()
	{
		A = [0x97 + X];

		if (Z == 1)
			return this.L0DB6_Done();

		A = [0x0310 + X];

		C = 1; temp = A - [0x96 + X]; if (Z == 0)
			return this.L0DB6_Done();

		Y = [0x3C];
		A = [0x0301 + X];
		YA = Y * A;
		A = Y;
		C = 0;
		A += [0x0300 + X] + C;
		return this.L0D96_Loop();
	}

	public void L0E15()
	{
		[0x14] |= 0x80;
		[0x13] = Y;
		this.L0BC7();
		Stack.Push(Y);
		Y = [0x3C];
		YA = Y * A;
		[0x15] = Y;
		[0x16] = 0x00;
		Y = [0x3C];
		A = Stack.Pop();
		YA = Y * A;
		YA += [0x15] + C;
	}

	public void L0E2B()
	{
		this.L0BC7();
		YA += [0x11] + C;
		[0x11] = YA;
		return;
	}

	public void L0E33()
	{
		[0x14] |= 0x80;
		Y = [0x3C];
		A = [0x0331 + X];
		YA = Y * A;
		A = Y;
		C = 0;
		A += [0x0330 + X] + C;
	}

	public void L0E40()
	{
		A <<= 1;

		if (C == 0)
			return this.L0E45_Skip();

		A ^= 0xFF;
	}

	public void L0E45_Skip()
	{
		Y = [0xA7 + X];
		YA = Y * A;
		A = Y;
		A ^= 0xFF;
	}

	public void L0E4B()
	{
		Y = [0x44];
		YA = Y * A;
		A = [0x0210 + X];
		YA = Y * A;
		A = [0x0251 + X];
		YA = Y * A;
		A = Y;
		YA = Y * A;
		A = [0xE6];
		YA = Y * A;
		A = Y;
		[0x0271 + X] = A;
		return;
	}

	public void L0E98()
	{
		A = 0xFF;
		X = [0xCB];
		[0x0100 + X] = A;
		[0x0360] = A;
		this.L11AE();
		this.L0FAE();
		A = [0x00];
		this.L1511();
		this.L1003();
		this.L11E6();
		A = 0x02;
		[0x03EE] = A;
		this.L0F06();
		A = 0x00;
		[0x03EE] = A;
		this.L0F06();
		YA = [0xE7];
		YA += [0xE5] + C;
		[0xE5] = YA;
		A = [0x016A];

		if (Z == 1)
			return this.L0ED1_Skip();

		this.L18A9();
	}

	public void L0ED1_Skip()
	{
		A = 0x00;
		Y = [0x0E];

		if (Z == 1)
			return this.L0ED9_Skip();

		A |= 0x02;
	}

	public void L0ED9_Skip()
	{
		Y = [0x016A];

		if (Z == 1)
			return this.L0EE0_Skip();

		A |= 0x04;
	}

	public void L0EE0_Skip()
	{
		Y = [0x0168];

		if (Z == 1)
			return this.L0EE7_Skip();

		A |= 0x08;
	}

	public void L0EE7_Skip()
	{
		Y = [0x0165];

		if (Z == 1)
			return this.L0EEE_Skip();

		A |= 0x10;
	}

	public void L0EEE_Skip()
	{
		Y = [0x03A0];

		if (Z == 1)
			return this.L0EF5_Loop();

		A |= 0x01;
	}

	public void L0EF5_Loop()
	{
		[0x07] = A;
		X = [0xCB];
		C = 1; temp = X - 0x60;

		if (C == 1)
			return this.L0EF5_Loop();

		A = [0x03F9];

		if (Z == 0)
			return this.L0F03_LoadData();

		return;
	}

	public void L0F03_LoadData()
	{
		return this.LFF45_LoadData();
	}

	public void L0F06()
	{
		X = A;
		A = [0x01 + X];

		if (N == 1)
			return this.L0F79();

		A = [0x00 + X];

		if (Z == 1)
			return this.L0F6B();

		C = 1; temp = A - [0x04 + X];

		if (Z == 1)
			return this.L0F73();

		X = [0x03EE];

		if (Z == 0)
			return this.L0F1C();

		C = 1; temp = A - 0xE0;

		if (C == 1)
			return this.L0F73();

	}

	public void L0F1C()
	{
		[0x0362] = A;
		A = [0x01 + X];
		A &= 0x20;

		if (Z == 1)
			return this.L0F25();

	}

	public void L0F25()
	{
		[0x03FA] = A;
		A = [0x0362];
		A--;
		A = (A >> 4) | (A << 4);
		A &= 0x0F;
		[0x03F8] = A;
		X = A;
		A = [0x9BC0 + X];
		X = A;
		A = [0x0378 + X];

		if (Z == 1)
			return this.L0F46();

		A = [0x0362];
		C = 1; temp = A - [0x0378 + X];

		if (C == 0)
			return this.L0F6B();


		if (C == 1)
			return this.L0F65();

	}

	public void L0F46()
	{
		this.L10DC();
		A = [0xDE];
		temp = A - [0x03A0];[0x03A0] |= A;
		temp = A - [0x001B];[0x001B] |= A;
		temp = A - [0x0192];[0x0192] &= ~A;
		temp = A - [0x0193];[0x0193] &= ~A;
		A &= [0x36];
		temp = A - [0x0192];[0x0192] |= A;
		A = [0xDE];
		A &= [0x35];
		temp = A - [0x0193];[0x0193] |= A;
		return this.L0F68();
	}

	public void L0F65()
	{
		this.L10DC();
	}

	public void L0F68()
	{
		this.L1107();
	}

	public void L0F6B()
	{
		X = [0x03EE];
		A = [0x0362];
	}

	public void L0F71()
	{
		[0x04 + X] = A;
	}

	public void L0F73()
	{
		A = 0x00;
		[0x0362] = A;
		return;
	}

	public void L0F79()
	{
		[0x15] = A;
		A &= 0x1F;
		[0x11] = A;
		Y = 0x03;
		A = [0x00 + X];
	}

	public void L0F83()
	{
		C = 1; temp = A - [0x0378 + Y];

		if (Z == 1)
			return this.L0F8D();

		Y--;

		if (N == 1)
			return this.L0F71();

		return this.L0F83();
	}

	public void L0F8D()
	{
		[0x12] = A;
		[0x03E3 + Y] = A;
		A = [0x15];
		[0x0160 + Y] = A;
		A = [0x11];

		if (Z == 0)
			return this.L0F9F();

		A = 0xFF;
		return this.L0FA3();
	}

	public void L0F9F()
	{
		A ^= 0x1F;
		A &= 0x1F;
	}

	public void L0FA3()
	{
		[0x03E7 + Y] = A;
		A = [0x12];
		return this.L0F71();
	}

	public void L0FAE()
	{
		A = [0x016D];
		[0x05] = A;
		YA = [0x04];
		[0xF4] = YA;
		Y = [0x03C2];
		A = [0x03BD];

		if (Z == 0)
			return this.L0FC5();

	}

	public void L0FBF()
	{
		YA = [0xF4];
		C = 1; temp = YA - [0xF4];

		if (Z == 0)
			return this.L0FBF();

	}

	public void L0FC5()
	{
		[0x00] = YA;
		YA = [0x06];
		[0xF6] = YA;
		Y = 0x00;
		A = [0x016C];

		if (Z == 0)
			return this.L0FD8_Done();

	}

	public void L0FD2()
	{
		YA = [0xF6];
		C = 1; temp = YA - [0xF6];

		if (Z == 0)
			return this.L0FD2();

	}

	public void L0FD8_Done()
	{
		[0x02] = YA;
		A = 0x00;
		[0x03BD] = A;
		[0x016C] = A;
		return;
	}

	public void L1003()
	{
		A = [0x00];
		C = 1; temp = A - 0xF0;

		if (C == 0)
			return this.L1013_Done();

		A &= 0x0F;
		A <<= 1;
		X = A;
		A = [0x01];
		Y = A;
		return [0x0FE3 + X]();
	}

	public void L1013_Done()
	{
		return;
	}

	public void L1040()
	{
		A = Y;

		if (Z == 1)
			return this.L1072_Done();


		if (N == 1)
			return this.L1072_Done();

		[0x016A] = X;
		A++;
		X = A;
		Y = 0x08;
		YA = Y * A;
		[0x0166] = A;
		[0x0167] = Y;
		A = 0x1F;
		Y = 0x00;
		A = YA / X; Y = YA % X;
		[0x12] = A;
		A = 0xE5;
		A = YA / X; Y = YA % X;
		[0x11] = A;
		A = [0x016A];
		C = 1; temp = A - 0x02;

		if (C == 1)
			return this.L106E();

		[0x11] ^= 0xFF;
		[0x12] ^= 0xFF;
		[0x11]++;   // 16-bit
	}

	public void L106E()
	{
		YA = [0x11];
		[0xE7] = YA;
	}

	public void L1072_Done()
	{
		return;
	}

	public void L1073()
	{
		A = [0x0E];

		if (Z == 1)
			return this.L1072_Done();

		X = 0x02;
		return this.L1040();
	}

	public void L10DC()
	{
		A = [0x10FF + X];
		[0xDE] = A;
		A ^= 0xFF;
		[0xE1] = A;
		A = X;
		[0xDF] = A;
		[0xE0] = A;
		[0xE0] <<= 1;
		A = (A >> 4) | (A << 4);
		[0xE2] = A;
		A = [0xDE];
		temp = A - [0x03FA];[0x03FA] &= ~A;
		A = [0x03FA];

		if (Z == 1)
			return this.L10FE_Done();

		A = [0xDE];
		temp = A - [0x03FA];[0x03FA] |= A;
	}

	public void L10FE_Done()
	{
		return;
	}

	public byte[] L10FF_Flags = new byte[]
	{
		0x01,
		0x02,
		0x04,
		0x08,
		0x10,
		0x20,
		0x40,
		0x80
	}

	public void L1107()
	{
		A = [0x03F8];
		A <<= 1;
		X = A;
		A = [0x9BD1 + X];
		Y = A;
		A = [0x9BD0 + X];
		[0x15] = YA;
		A = [0x0362];
		A--;
		A &= 0x0F;
		A <<= 1;
		Y = A;
		A = [[0x15] + Y];
		[0xCC] = A;
		Y++;
		A = [[0x15] + Y];
		[0xCD] = A;
		X = [0xDF];
		A = 0x00;
		[0x036B + X] = A;
		[0x0373 + X] = A;
		[0x03A5 + X] = A;
		[0x03A1 + X] = A;
		[0x03BE + X] = A;
		[0x03B1 + X] = A;
		[0x03DF + X] = A;
		[0x03DB + X] = A;
		Y = A;
		A++;
		[0xDA + X] = A;
		A = [0x0362];
		[0x0378 + X] = A;
		A = [0xDE];
		temp = A - [0x00E3];[0x00E3] &= ~A;
		temp = A - [0x03ED];[0x03ED] &= ~A;
		temp = A - [0x03F7];[0x03F7] |= A;
		A = 0xDC;
		[0x03EF + X] = A;
		A = [[0xCC] + Y];
		this.L17A7();
		A = [[0xCC] + Y];
		this.L17AD();
		A = [0xE2];
		A |= 0x05;
		Y = 0x00;
		this.L11A2();

		// DSP
		A = [0xDE];
		[0xF2] = 0x5C;
		[0xF3] = A;

		A = [0xE1];
		A &= [0x3ED];
		[0x03ED] = A;
		Y = 0x04;
		X = [0xDF];
		A = [0x0378 + X];
	}

	public void L1185()
	{
		C = 1; temp = A - [0x03E2 + Y];

		if (Z == 1)
			return this.L118E();


		Y--; if (Z == 0)
			return this.L1185();

		return this.L1196();
	}

	public void L118E()
	{
		A = 0x00;
		[0x03E2 + Y] = A;
		[0x03E6 + Y] = A;
	}

	public void L1196()
	{
		X = [0xE0];
		YA = [0xCC];
		[0x0194 + X] = A;
		A = Y;
		[0x0195 + X] = A;
		return;
	}

	public void L11A2()
	{
		D = 1;
		X = [0x00CB];
		[X++] = A;
		[0x00CB] = X;
		D = 0;
		return;
	}

	public void L11AE()
	{
		D = 1;
		X = 0x00;
	}

	public void L11B1()
	{
		A = [X++];

		if (N == 1)
			return this.L11BD();

		// DSP
		[0x00F2] = A;
		A = [X++];
		[0x00F3] = A;

		return this.L11B1();
	}

	public void L11BD()
	{
		D = 0;
		A = [0x03EB];
		[0x35] = A;
		A = [0x34];
		A &= 0xE0;
		A |= [0x0377];
		[0x34] = A;
		Y = 0x03;
	}

	public void L11CE_Loop()
	{
		// DSP
		A = [0x11E2 + Y];
		[0xF2] = A;
		A = [0x03EA + Y];
		[0xF3] = A;

		Y--; if (Z == 0)
			return this.L11CE_Loop();

		[0xCB] = Y;
		[0x03ED] = Y;
		[0x03EC] = Y;
		return;
	}

	public void L11E6()
	{
		A = 0x01;
		X = 0x00;
		this.L1203();
		A = 0x02;
		X = 0x01;
		this.L1203();
		A = 0x04;
		X = 0x02;
		this.L1203();
		A = 0x08;
		X = 0x03;
		this.L1203();
		return;
	}

	public void L1203()
	{
		A &= [0x3A0];

		if (Z == 1)
			return this.L1247_Done();

		this.L10DC();
		X = [0xE0];
		A = [0x0195 + X];
		Y = A;
		A = [0x0194 + X];
		[0xCC] = YA;
		X = [0xDF];
		[0xDA + X]--;

		if (Z == 0)
			return this.L123E();

		A = [0xDE];
		A &= [0x3F7];

		if (Z == 1)
			return this.L1230_Loop();

		temp = A - [0x03F7];[0x03F7] &= ~A;
		temp = A - [0x03EB];[0x03EB] &= ~A;
		Y = 0x00;
		A = [[0xCC] + Y];
		this.L16BF();
	}

	public void L1230_Loop()
	{
		this.L1375();
		X = [0xDF];
		A = [0x0378 + X];

		if (Z == 1)
			return this.L1248_Skip();

		A = [0xDA + X];

		if (Z == 1)
			return this.L1230_Loop();

	}

	public void L123E()
	{
		this.L127B();
		this.L1333();
		this.L1196();
	}

	public void L1247_Done()
	{
		return;
	}

	public void L1248_Skip()
	{
		A = [0xDE];
		temp = A - [0x0036];[0x0036] &= ~A;
		temp = A - [0x0035];[0x0035] &= ~A;
		temp = A - [0x03EB];[0x03EB] &= ~A;
		temp = A - [0x03A0];[0x03A0] &= ~A;
		temp = A - [0x001B];[0x001B] &= ~A;
		A &= [0x192];
		temp = A - [0x0036];[0x0036] |= A;
		A = [0xDE];
		A &= [0x193];
		temp = A - [0x0035];[0x0035] |= A;
		X = [0xE0];
		A = [0x0211 + X];
		this.L0922_LoadInstrument();
		A = X;
		A = (A >> 4) | (A << 4);
		A >>= 1;
		A |= 0x07;
		Y = A;
		A = [0x0350 + X];
		return this.L05EA_WriteDspRegister();
	}

	public void L127B()
	{
		X = [0xDF];
		A = [0x036F + X];
		Y = 0x00;
		[0x11] = YA;
		A = [0x0373 + X];

		if (Z == 1)
			return this.L129C();


		if (N == 0)
			return this.L128C();

		Y--;
	}

	public void L128C()
	{
		YA += [0x11] + C;

		if (N == 1)
			return this.L1297();

		Y--;

		if (Z == 0)
			return this.L1299();

		A = 0xFF;
		return this.L1299();
	}

	public void L1297()
	{
		A = 0x00;
	}

	public void L1299()
	{
		[0x036F + X] = A;
	}

	public void L129C()
	{
		A = [0x036B + X];
		[0x11] = A;
		A <<= 1;

		if (C == 1)
			return this.L12A9();

		[0x12] = 0x00;
		return this.L12AC();
	}

	public void L12A9()
	{
		[0x12] = 0xFF;
	}

	public void L12AC()
	{
		A = [0x0363 + X];
		Y = A;
		A = [0x0367 + X];
		YA += [0x11] + C;

		if (N == 0)
			return this.L12BB();

		YA = [0x0F];
		return this.L12C3();
	}

	public void L12BB()
	{
		C = 1; temp = Y - 0x1E;

		if (C == 0)
			return this.L12C3();

		Y = 0x1E;
		A = 0x00;
	}

	public void L12C3()
	{
		[0x11] = YA;
		[0x0367 + X] = A;
		A = Y;
		[0x0363 + X] = A;
		A = [0x036F + X];
		Y = A;
		A = [0x03EF + X];
		YA = Y * A;
		A = [0x0360];
		YA = Y * A;
		[0x15] = Y;
		A = [0x0361];
		A &= 0x01;

		if (Z == 1)
			return this.L12E7();

		[0x12] = 0x0F;
		[0x11] = 0x00;
	}

	public void L12E7()
	{
		A = [0xE2];
		[0x13] = A;
	}

	public void L12EB()
	{
		Y = [0x12];
		A = [0x1315 + Y];
		C = 1;
		A -= [0x1314 + Y] + !C;
		Y = [0x11];
		YA = Y * A;
		A = Y;
		Y = [0x12];
		C = 0;
		A += [0x1314 + Y] + C;
		Y = [0x15];
		YA = Y * A;
		A = [0x13];
		this.L11A2();
		Y = 0x1E;
		A = 0x00;
		YA -= [0x11];
		[0x11] = YA;
		[0x13]++;

		if (([0x13] & 0x02) == 0)
			return this.L12EB();

		return;
	}

	public void L1333()
	{
		X = [0xDF];
		A = [0x03B1 + X];

		if (Z == 0)
			return this.L133B();

		return;
	}

	public void L133B()
	{
		X = [0xE0];
		A = [0x03B6 + X];
		[0x16] = A;
		A = [0x03B5 + X];
		[0x15] = A;
		X = [0xDF];
		A = [0x03A9 + X];
		Y = A;
		A = [0x03AD + X];
		YA += [0x15] + C;
		[0x03AD + X] = A;
		A = Y;
		[0x03A9 + X] = A;
		C = 1; temp = A - [0x03B1 + X];

		if (Z == 0)
			return this.L1363();

		A = 0x00;
		[0x03B1 + X] = A;
	}

	public void L1363()
	{
		A = [0x03DF + X];
		C = 0;
		A += [0x03AD + X] + C;
		[0x11] = A;
		A = [0x03A9 + X];

		if (C == 0)
			return this.L1372();

		A++;
	}

	public void L1372()
	{
		return this.L1621();
	}

	public void L1375()
	{
		A = 0x13;
		Stack.Push(A);
		A = 0x75;
		Stack.Push(A);
		Y = 0x00;
		A = [[0xCC] + Y];

		if (Z == 1)
			return this.L13AC();

		C = 1; temp = A - 0xC8;

		if (C == 1)
			return this.L1398();

		X = [0xDF];
		C = 1; temp = A - 0x80;

		if (C == 0)
			return this.L138E();

		return this.L15B0();
	}

	public void L138E()
	{
		C = 1; temp = A - 0x40;

		if (C == 0)
			return this.L1395();

		return this.L1724();
	}

	public void L1395()
	{
		return this.L1431();
	}

	public void L1398()
	{
		C = 1;
		A -= 0xC8 + !C;
		A <<= 1;
		X = A;
		A = [0x13B6 + X];
		Stack.Push(A);
		A = [0x13B5 + X];
		Stack.Push(A);
		X = [0xDF];
		[0xCC]++;   // 16-bit
		A = [[0xCC] + Y];
	}

	public void L13AB_Done()
	{
		return;
	}

	public void L13AC()
	{
		X = [0xDF];
		[0x0378 + X] = A;
		A = Stack.Pop();
		A = Stack.Pop();
		return this.L13AB_Done();
	}

	public void L1431()
	{
		[0xCC]++;   // 16-bit
		return this.L1438();
	}

	public void L1438()
	{
		[0xDA + X] = A;
		A = Stack.Pop();
		A = Stack.Pop();
		return;
	}

	public void L1511()
	{
		C = 1; temp = A - 0xF0;

		if (C == 1)
			return this.L1549();

		C = 1; temp = A - 0xE0;

		if (C == 1)
			return this.L151A();

		return;
	}

	public void L151A()
	{
		A &= 0x0F;
		C = 1; temp = A - [0x0E];

		if (Z == 1)
			return this.L1549();

		[0x0E] = A;
		A = 0x00;
		[0xB9] = A;
		[0x016A] = A;
		[0xE7] = A;
		[0xE8] = A;
		[0x0168] = A;
		[0x016B] = A;
		[0xB8] = A;
		Y = [0x01];

		if (Z == 1)
			return this.L1544();

		this.L1073();
		A = 0x00;
		[0xE5] = A;
		[0xE6] = A;
		return this.L1549();
	}

	public void L1544()
	{
		A--;
		[0xE6] = A;
		[0xE5] = A;
	}

	public void L1549()
	{
		[0x00] = [0x04];
		return;
	}

	public void L15B0()
	{
		[0xCC]++;   // 16-bit
		[0x03A9 + X] = A;
		Stack.Push(A);
		A = [0xDE];
		A &= [0x3EB];

		if (Z == 1)
			return this.L15D4();

		A = Stack.Pop();
		C = 1; temp = A - 0xA0;

		if (C == 1)
			return this.L15CD();

		C = 0;
		A += [0x03A5 + X] + C;
		A &= 0x1F;
		[0x0377] = A;
		return this.L15F4();
	}

	public void L15CD()
	{
		A = [0xDE];
		temp = A - [0x03EB]; [0x03EB] &= ~A;
		return this.L1619();
	}

	public void L15D4()
	{
		A = [0x03DB + X];
		Y = [0x19];
		[0x19] <<= 1;
		YA = Y * A;
		A = Y;
		C = 0;
		A += [0x03DF + X] + C;
		[0x11] = A;
		A = Stack.Pop();

		if (C == 0)
			return this.L15E7();

		A++;
	}

	public void L15E7()
	{
		this.L1621();
		X = [0xDF];
		A = 0x00;
		[0x03AD + X] = A;
		[0x03B1 + X] = A;
	}

	public void L15F4()
	{
		A = [0xDE];
		A &= [0xE3];

		if (Z == 1)
			return this.L1619();

		A &= [0xE4];

		if (Z == 0)
			return this.L1619();

		A = [0xDE];
		temp = A - [0x00E4];[0x00E4] |= A;
		X = [0xE0];
		A = [0x038C + X];
		[0x15] = A;
		A = [0x038D + X];
		[0x16] = A;
		A = X;
		C = 0;
		A += 0x08 + C;
		X = A;
		this.L1808();
		return this.L161E();
	}

	public void L1619()
	{
		A = [0x03A1 + X];
		[0xDA + X] = A;
	}

	public void L161E()
	{
		A = Stack.Pop();
		A = Stack.Pop();
		return;
	}

	public void L1621()
	{
		C = 0;
		A += [0x03A5 + X] + C;
		C = 1; temp = A - 0x80;

		if (C == 0)
			return this.L1632();

		C = 1; temp = A - 0xC8;

		if (C == 1)
			return this.L1632();

		A <<= 1;
		C = 1; temp = A - 0x90;

		if (C == 0)
			return this.L1634();
	}

	public void L1632()
	{
		A = 0x00;
	}

	public void L1634()
	{
		Y = 0x00;
		X = 0x18;
		A = YA / X; Y = YA % X;
		X = A;
		A = [0x05F9 + Y];
		[0x15] = A;
		A = [0x05FA + Y];
		[0x16] = A;
		A = [0x05FC + Y];
		Stack.Push(A);
		A = [0x05FB + Y];
		Y = Stack.Pop();
		YA -= [0x15];
		Y = [0x11];
		YA = Y * A;
		A = Y;
		Y = 0x00;
		YA += [0x15] + C;
		[0x16] = Y;
		A <<= 1;
		Cpu.ROL([0x16]);
		[0x15] = A;
		return this.L1664();
	}

	public void L165F()
	{
		[0x16] <<= 1;
		Cpu.ROR([0x15]);
		X++;
	}

	public void L1664()
	{
		C = 1; temp = X - 0x06;

		if (Z == 0)
			return this.L165F();

		X = [0xE0];
		A = [0x0220 + X];
		Y = [0x16];
		YA = Y * A;
		[0x17] = YA;
		A = [0x0220 + X];
		Y = [0x15];
		YA = Y * A;
		Stack.Push(Y);
		A = [0x0221 + X];
		Y = [0x15];
		YA = Y * A;
		YA += [0x17] + C;
		[0x17] = YA;
		A = [0x0221 + X];
		Y = [0x16];
		YA = Y * A;
		Y = A;
		A = Stack.Pop();
		YA += [0x17] + C;
		Stack.Push(Y);
		Y = A;
		A = [0xE2];
		A |= 0x02;
		this.L11A2();
		A = [0xE2];
		A |= 0x03;
		Y = Stack.Pop();
		return this.L11A2();
	}

	public void L16B9()
	{
		A = [0xDE];
		temp = A - [0x03EB];[0x03EB] |= A;
		return;
	}

	public void L16BF()
	{
		C = 1; temp = A - 0x40;

		if (C == 0)
			return this.L16D7();

		[0x11] = A;

		if (([0x11] & 0x40) == 0)
			return this.L16CB();

		this.L173B();
	}

	public void L16CB()
	{
		A = [0x11];

		if (([0x11] & 0x80) == 0)
			return this.L16D3();

		this.L16B9();
	}

	public void L16D3()
	{
		A = [0x11];
		A &= 0x3F;
	}

	public void L16D7()
	{
		Stack.Push(A);
		Y = 0x06;
		YA = Y * A;
		[0x15] = YA;
		C = 0;
		[0x15] += 0x80;
		[0x16] += 0x19;
		X = [0xE0];
		Y = 0x04;
		A = [[0x15] + Y];
		[0x0221 + X] = A;
		Y++;
		A = [[0x15] + Y];
		[0x0220 + X] = A;
		A = [0xE2];
		A |= 0x04;
		Y = Stack.Pop();
		[0xCC]++;   // 16-bit
		return this.L11A2();
	}

	public void L1724()
	{
		Y = A;
		A &= 0x0F;
		[0x11] = A;
		A = Y;
		A &= 0x70;
		A <<= 1;
		A |= [0x11];
		A |= 0x10;
		[0xCC]++;   // 16-bit
		Y = A;
		A = [0xE2];
		A |= 0x07;
		return this.L11A2();
	}

	public void L173B()
	{
		A = [0xDE];
		temp = A - [0x03ED];[0x03ED] |= A;
		return;
	}

	public void L17A7()
	{
		[0x036F + X] = A;
		[0xCC]++;   // 16-bit
		return;
	}

	public void L17AD()
	{
		[0x11] = A;
		A = [0xDE];

		if (([0x11] & 0x80) != 0)
			return this.L17C1();

		C = [0x0165] >> 0 & 1;

		if (C == 1)
			return this.L17BC();


		if (([0x11] & 0x20) == 0)
			return this.L17C1();

	}

	public void L17BC()
	{
		temp = A - [0x0036];[0x0036] |= A;
		return this.L17C4();
	}

	public void L17C1()
	{
		temp = A - [0x0036];[0x0036] &= ~A;
	}

	public void L17C4()
	{
		if (([0x11] & 0x40) != 0)
			return this.L17D9();

		X = [0x03EE];
		A = [0x01 + X];
		X = [0xDF];
		[0x03BE + X] = A;
		A &= 0x1F;

		if (Z == 1)
			return this.L17D9();

		A ^= 0x1F;
		return this.L17DB();
	}

	public void L17D9()
	{
		A = [0x11];
	}

	public void L17DB()
	{
		A &= 0x1F;
		[0x0363 + X] = A;
		A = 0x00;
		[0x0367 + X] = A;
		[0xCC]++;   // 16-bit
		return;
	}

	public void L1808()
	{
		YA = [0xCC];
		[0x037C + X] = A;
		A = Y;
		[0x037D + X] = A;
		YA = [0x15];
		[0xCC] = YA;
		return;
	}

	public void L18A9()
	{
		A = [0x0E];

		if (Z == 1)
			return this.L18CF();

		A = 0xFF;
		[0x45] = A;
		A++;
		[0x016B] = A;
		[0x47] = A;
		[0x48] = A;
		D = 1;
		[0x66]--;   // 16-bit
		D = 0;

		if (Z == 0)
			return this.L18E3_Done();

		A = [0x016A];
		C = 1; temp = A - 0x01;

		if (Z == 1)
			return this.L18CF();

		A = 0xFF;
		[0xE6] = A;
		[0xE5] = A;
		A++;
		return this.L18DA();
	}

	public void L18CF()
	{
		A = 0x00;
		[0x0E] = A;
		[0xE6] = A;
		[0xE5] = A;
		[0x0168] = A;
	}

	public void L18DA()
	{
		[0x016A] = A;
		[0xE7] = A;
		[0xE8] = A;
		[0x45] = A;
	}

	public void L18E3_Done()
	{
		return;
	}

	public byte[] L1980_InstrumentData = new byte[]
	{
		0x00, 0xFE, 0xE0, 0xB8, 0x04, 0x00,
		0x01, 0xFF, 0xE0, 0xB8, 0x07, 0x80, 
		0x02, 0xFF, 0xE0, 0xB8, 0x03, 0x10, 
		0x03, 0xFF, 0xE0, 0xB8, 0x03, 0x30, 
		0x04, 0xFF, 0xE0, 0xB8, 0x06, 0x00, 
		0x05, 0xFF, 0xE0, 0xB8, 0x03, 0xC0, 
		0x06, 0xA4, 0xEB, 0xB8, 0x02, 0x40, 
		0x07, 0xFF, 0xE0, 0xB8, 0x05, 0x60, 
		0x08, 0xFF, 0xE0, 0xB8, 0x06, 0x60, 
		0x09, 0xFF, 0xE0, 0xB8, 0x07, 0x80, 
		0x09, 0xFF, 0xE0, 0xB8, 0x07, 0x80, 
		0x09, 0xFF, 0xE0, 0xB8, 0x07, 0x80, 
		0x0C, 0xFF, 0xE0, 0xB8, 0x07, 0xB0, 
		0x0D, 0xFF, 0xE0, 0xB8, 0x05, 0x50, 
		0x0E, 0xFF, 0xE0, 0xB8, 0x07, 0xB0, 
		0x0F, 0xFF, 0xE0, 0xB8, 0x06, 0x40, 
	}







	public void LFF45_LoadData()
	{
		[0xF4] = 0x34;
		[0xF5] = 0x12;
		[0xF6] = 0x00;
		[0xF7] = 0x00;

		X = 0x7F;
	}

	public void LFF53_Wait()
	{
		C = 1; temp = X - [0xF6];

		if (Z == 0)
			return this.LFF53_Wait();

		// Pointer15 = Input01;
		YA = [0xF4];
		[0x15] = YA;
		[0xF6] = X;
		[0xF4] = YA;
		Y = 0x00;
	}

	public void LFF61_Loop()
	{
		C = 1; temp = X - [0xF6];

		if (Z == 1)
			return this.LFF61_Loop();

		// X = Input2
		X = [0xF6];

		if (N == 1)
			return this.LFF7B_Skip();

		// [Pointer15++] = Input0;
		A = [0xF4];
		[[0x15] + Y] = A;
		Y++;

		// [Pointer15++] = Input1;
		A = [0xF5];

		// Output2 = X;
		[0xF6] = X;
		[[0x15] + Y] = A;
		Y++;

		if (Z == 0)
			return this.LFF61_Loop();

		// Pointer15 += 0x100;
		[0x16]++;
		return this.LFF61_Loop();
	}

	public void LFF7B_Skip()
	{
		A = [0xF7];

		if (Z == 1)
			return this.LFF85_Skip();

		if (N == 0)
			return this.LFF45_LoadData();

		A = 0x00;
		return this.LFF8C_Skip();
	}

	public void LFF85_Skip()
	{
		// Clear Registers
		[0x03F9] = A;
		[0x0E] = A;
		[0x08] = A;
	}

	public void LFF8C_Skip()
	{
		// Clear Registers
		[0x00] = A;
		[0x04] = A;

		// Clear Inputs
		X = 0x03;
	}

	public void LFF92_Loop()
	{
		[0xF4 + X] = A;
		X--;

		if (N == 0)
			return this.LFF92_Loop();

		return;
	}
}